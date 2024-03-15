using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 소켓 사용 위해 추가
using System.Net;
using System.Net.Sockets;

namespace BaseballGameServer
{
    public partial class ServerForm : Form
    {
        IPAddress ip; // 서버 주소
        int port; // 포트 번호
        Socket toClient; // 서버 소켓

        Boolean onoff; // 서버 on/off
        public static string msg = null; // 메시지 문자열화

        //클라이언트 메시지를 받을 버퍼 선언
        private byte[] bytes = new byte[256 + 1];
        //private int buffersize = sizeof(bytes);

        //클라이언트 정보 저장
        public List<Socket> clientIP = new List<Socket>();

        public ServerForm()
        {
            InitializeComponent();

            //서버 소켓을 생성한다 (+) Invoke
            toClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            onoff = false;

            ip = IPAddress.Loopback; // 로컬 서버 주소 사용
            port = 5000; // 포트 번호 지정

            ipaddress.Text = ip.ToString();
            portnumber.Text = port.ToString();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            //주소가 없으면, 로컬 서버 주소를 사용한다
            if (ipaddress.Text.Trim() == "")
                ipaddress.Text = IPAddress.Loopback.ToString();
        }

        private void serveronoff_Click(object sender, EventArgs e)
        {
            onoff = !onoff;

            if (onoff) // true, on
            {
                try
                {
                    //스스로의 EndPoint 주소를 생성한다
                    IPEndPoint serverEP = new IPEndPoint(ip, port);

                    //사용 포트 번호에 소켓을 바인딩한다
                    toClient.Bind(serverEP);

                    //연결 요청에 대한 대기를 시작한다
                    toClient.Listen(10);

                    // 비동기적으로 클라이언트의 연결 요청을 받는다
                    toClient.BeginAccept(AcceptCallback, null);

                    MessageBox.Show("서버가 구동 되었습니다!");
                    
                    serveronoff.Text = "서버 ON";
                }
                catch
                {
                    MessageBox.Show("서버 시작 시 오류가 발생하였습니다.");

                    //바인딩 되어있는지 확인한다
                    if (toClient.IsBound)
                    {
                        //서버를 종료한다
                        toClient.Close();
                        this.Close();
                    }
                }
            }
            else // false, off
            {
                //바인딩 되어있는지 확인한다
                if (toClient.IsBound)
                {
                    //서버를 종료한다
                    try
                    {
                        toClient.Shutdown(SocketShutdown.Both);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        toClient.Close(0);
                        serveronoff.Text = "서버 OFF";
                    }
                }
            }
        }

        void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                //클라이언트의 연결 요청을 수락한다
                Socket sockClient = toClient.EndAccept(ar);

                //또 다른 클라이언트의 연결을 대기한다
                toClient.BeginAccept(AcceptCallback, null);

                //4096 바이트 크기 바이트 배열 가진 AsyncObject 클래스를 생성한다
                AsyncObject obj = new AsyncObject(4096);

                //작업 중인 소켓을 저장하기 위해 클라이언트 소켓을 할당한다
                obj.WorkingSocket = sockClient;

                // 연결된 클라이언트를 리스트에 추가해준다
                clientIP.Add(sockClient);
                
                ListViewItem lvi = new ListViewItem();
                lvi.Text = sockClient.RemoteEndPoint.ToString();
                lvi.SubItems.Add("");
                clientView.Items.Add(lvi);

                //동기적으로 클라이언트에게 해당 EnpPoint 정보를 보낸다
                //byte[] bDts = Encoding.UTF8.GetBytes(string.Format("client;{0};",sockClient.RemoteEndPoint.ToString()));

                byte[] bDts = Encoding.UTF8.GetBytes("client"+ '\x01' + sockClient.RemoteEndPoint.ToString() + '\x01');
                
                Socket socket = sockClient;

                //socket.BeginSend(bDts, 0, bDts.Length, SocketFlags.None, DataSend, socket);
                socket.Send(bDts);
                //socket.BeginSend(bDts, 0, 4096, 0, new AsyncCallback(DataSend), socket);

                //비동기적으로 들어오는 메시지를 수신한다
                sockClient.BeginReceive(obj.Buffer, 0, obj.BufferSize, SocketFlags.None, DataReceived, obj);
            }
            catch
            {
                MessageBox.Show("클라이언트와 연결하지 못했습니다.");
                return;
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //폼을 닫을 때 소켓을 종료한다
            toClient.Close();
        }

        void DataSend(IAsyncResult ar)
        {
            //BeginReceive에서 넘어온 메시지를 AsyncObject 형식으로 변환한다
            AsyncObject obj = (AsyncObject)ar.AsyncState;

            try
            {
                //메시지를 전송하고 전송한 바이트를 가져온다 (End)
                int sendBytes = obj.WorkingSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("자료 송신 도중에 오류가 발생했습니다!");
            }
        }

        void DataReceived(IAsyncResult ar) //비동기적으로 들어오는 메시지를 수신(receive)한다
        {
            try
            {
                //BeginReceive에서 넘어온 메시지를 AsyncObject 형식으로 변환한다
                AsyncObject obj = (AsyncObject)ar.AsyncState;

                //메시지를 수신하고 수신 받은 바이트를 가져온다 (End)
                int recvBytes = obj.WorkingSocket.EndReceive(ar);

                //수신받은 메시지 크기가 1 이상일 때에만 처리한다
                if (recvBytes <= 0)
                    return;

                //버퍼 형식의 메시지를 문자열 형식으로 변환한다
                string msg = Encoding.UTF8.GetString(obj.Buffer);

                //세미콜론을 기준으로 자른다
                string[] tokens = msg.Split('\x01');

                //첫 번째 토큰으로 명령어를 구분하여 처리하고, 동기적으로 송신(send)한다
                //(1) 게임 시작
                if (tokens[0] == "start")
                {
                    //MessageBox.Show(string.Format("start:도착~"));
                    int k = 0, m = 0;
                    int[] num = new int[4];
                    Random rand = new Random();

                    //번호 한 개씩 겹치지 않게 랜덤 생성한다
                    for (k = 0; k < 4; k++)
                    {
                        num[k] = rand.Next(0, 10);

                        for (m = k; m >= 0; m--)
                        {
                            if ((k != m) && (num[k] == num[m]))
                            {
                                k--;
                                break;
                            }
                        }
                    }

                    string question = num[0].ToString() + '\x01' + num[1].ToString() + '\x01' + num[2].ToString() + '\x01' + num[3].ToString();

                    //MessageBox.Show(string.Format("start: 중간 점검~ {0}", question));

                    //clientView 의 해당 클라이언트 번호 값 다음 열에 문제를 저장하고 빠져나온다
                    for (k=0; k<clientView.Items.Count; k++)
                    {
                        if(clientView.Items[k].SubItems[0].Text == tokens[1])
                        {
                            //MessageBox.Show(string.Format("start: 클라이언트 검색 완료 1"));
                            clientView.Items[k].SubItems[1].Text = question;
                            break;
                        }
                    }

                    for (k = clientIP.Count - 1; k >= 0; k--)
                    {
                        if (clientIP[k].RemoteEndPoint.ToString() == tokens[1])
                        {
                            //MessageBox.Show(string.Format("start: 클라이언트 검색 완료 2"));
                            break;
                        }
                    }

                    // byte[] bDts = Encoding.UTF8.GetBytes(string.Format("start;{0};", question));
                    byte[] bDts = Encoding.UTF8.GetBytes("start" + '\x01' + question + '\x01');
                    
                    Socket socket = clientIP[k]
                        ;
                    socket.Send(bDts);
                    //socket.BeginSend(bDts, 0, 4096, SocketFlags.None, DataSend, socket);

                    //MessageBox.Show(string.Format("start: 전송 완료~ {0}", question));
                }
                //(2) 제출한 답을 리스트뷰에 저장된 문제와 비교한다
                else if(tokens[0] == "answer")
                {
                    int k = 0, m = 0, n = 0;
                    int S = 0, B = 0;
                    string question;
                    string answer = string.Format("{0}{1}{2}{3}", tokens[2], tokens[3], tokens[4], tokens[5]);

                    for (k = 0; k < clientView.Items.Count; k++)
                    {
                        if (clientView.Items[k].SubItems[0].Text == tokens[1])
                        {
                            //MessageBox.Show(string.Format("answer: 클라이언트 검색 완료 1"));
                            question = clientView.Items[k].SubItems[1].Text;
                            string[] number = question.Split('\x01');

                            for (m = 0; m < 4; m++)
                                for (n = 0; n < 4; n++)
                                    if (number[m] == tokens[n + 2])
                                        if (m == n)
                                            //스트라이크
                                            S += 1;
                                        else
                                            //볼
                                            B += 1;

                            byte[] bDts;
                            if (S == 4) // in
                            {
                                //게임 랭킹 리스트에 점수 + 클라이언트 번호 + 문제를 저장한다
                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = (int.Parse(tokens[6]) + 1).ToString();
                                lvi.SubItems.Add(clientIP[k].RemoteEndPoint.ToString());
                                lvi.SubItems.Add(question);
                                rankView.Items.Add(lvi);

                                bDts = Encoding.UTF8.GetBytes("succ" + '\x01' + S.ToString() + "S" + '\x01' + answer + '\x01');
                            }
                            else if (S == 0 && B == 0) // out
                                bDts = Encoding.UTF8.GetBytes("fail" + '\x01' + "out" + '\x01' + answer + '\x01');
                            else if (S > 0 && B == 0) // strike
                                bDts = Encoding.UTF8.GetBytes("fail" + '\x01' + S.ToString() + "S" + '\x01' + answer + '\x01');
                            else if (B > 0 && S == 0) // ball
                                bDts = Encoding.UTF8.GetBytes("fail" + '\x01' + B.ToString() + "B" + '\x01' + answer + '\x01');
                            else // strike and ball
                                bDts = Encoding.UTF8.GetBytes("fail" + '\x01' + S.ToString() + "S " + B.ToString() + "B" + '\x01' + answer + '\x01');

                            for (k = clientIP.Count - 1; k >= 0; k--)
                            {
                                if (clientIP[k].RemoteEndPoint.ToString() == tokens[1])
                                {
                                    //MessageBox.Show(string.Format("answer: 클라이언트 검색 완료 2"));
                                    break;
                                }
                            }

                            Socket socket = clientIP[k];
                            socket.Send(bDts);
                            //socket.BeginSend(bDts, 0, bDts.Length, SocketFlags.None, DataSend, socket);

                            //MessageBox.Show(string.Format("answer: 결과 보냄~ {0}S {1}B", S, B));

                            break;
                        }
                    }
                }
                //(3) 클라이언트가 나갔다는 신호를 받고 접속 리스트에서 정보를 삭제한다
                else if (tokens[0] == "exit")
                {
                    int k = 0;
                    for (k = clientView.Items.Count - 1; k >= 0; k--)
                    {
                        if (clientView.Items[k].SubItems[0].Text == tokens[1])
                        {
                            //MessageBox.Show(string.Format("exit: 클라이언트 검색 완료 1"));
                            clientView.Items.RemoveAt(k);
                            break;
                        }
                    }

                    for (k = clientIP.Count - 1; k >= 0; k--)
                    {
                        if (clientIP[k].RemoteEndPoint.ToString() == tokens[1])
                        {
                            //MessageBox.Show(string.Format("exit: 클라이언트 검색 완료 2"));
                            clientIP.RemoveAt(k);
                            break;
                        }
                    }
                }

                //기존의 버퍼 내용을 지운다
                obj.ClearBuffer();

                //비동기적 수신을 대기한다
                obj.WorkingSocket.BeginReceive(obj.Buffer, 0, obj.BufferSize, SocketFlags.None, DataReceived, obj);
            }
            catch
            {
                return;
            }
        }
    }

    public class AsyncObject //클라이언트와 연결 시 이벤트 처리
    {
        public byte[] Buffer;
        public Socket WorkingSocket;
        public readonly int BufferSize;

        public AsyncObject(int bufferSize) //사이즈만큼의 버퍼를 생성한다
        {
            BufferSize = bufferSize;
            Buffer = new byte[BufferSize];
        }
        public void ClearBuffer() //버퍼를 비운다
        {
            Array.Clear(Buffer, 0, BufferSize);
        }
    }
}