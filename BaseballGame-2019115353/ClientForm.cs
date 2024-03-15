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

namespace BaseballGame_2019115353
{
    public partial class ClientForm : Form
    {
        IPAddress ip; // 서버 주소
        int port; // 포트 번호
        Socket toServer; // 클라이언트 소켓
        
        string myclient; // 나의 클라이언트 번호

        public ClientForm()
        {
            InitializeComponent();

            //클라이언트 소켓을 생성한다 (+) Invoke
            toServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            
            ip = IPAddress.Loopback; // 로컬 서버 주소 사용
            port = 5000; // 포트 번호 지정

            ipaddress.Text = ip.ToString();
            portnumber.Text = port.ToString();

            //숫자 입력 제한
            num1.MaxLength = 1;
            num2.MaxLength = 1;
            num3.MaxLength = 1;
            num4.MaxLength = 1;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            //주소가 없으면, 로컬 서버 주소를 사용한다
            if (ipaddress.Text.Trim() == "")
                ipaddress.Text = IPAddress.Loopback.ToString();

            try
            {
                //서버에 연결한다
                toServer.Connect(ip, port);

                //연결을 완료하고,
                AsyncObject obj = new AsyncObject(4096);

                //작업 중인 소켓을 저장하기 위해 클라이언트 소켓을 할당한다
                obj.WorkingSocket = toServer;

                //비동기적 수신을 대기한다
                toServer.BeginReceive(obj.Buffer, 0, obj.BufferSize, SocketFlags.None, DataReceived, obj);
            }
            catch
            {
                MessageBox.Show("연결에 실패했습니다!");
                this.Close();
                return;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            // 게임 시작 명령어 + 클라이언트 번호를 동기적으로 송신한다
            //string str = string.Format("start;{0};", myclient);

            byte[] bDts = Encoding.UTF8.GetBytes("start" + '\x01' + myclient + '\x01');

            toServer.Send(bDts);
            //toServer.BeginSend(bDts, 0, bDts.Length, 0, DataSend, toServer);

            recordView.Items.Clear();
            start.Text = "다시 하기";
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
                
                //(0) 맨 처음 연결 후 송신된 나의 클라이언트 번호를 수신하여 저장한다
                if(tokens[0] == "client")
                {
                    myclient = tokens[1];
                }
                //(1) 게임 시작
                else if(tokens[0] == "start")
                {
                    label1.Text = "[Start] 숫자를 입력해 주세요!";

                    textBox1.Text = tokens[1];

                    num1.ReadOnly = false;
                    num2.ReadOnly = false;
                    num3.ReadOnly = false;
                    num4.ReadOnly = false;

                    num1.Focus();
                }
                //(2-1) 보낸 답에 대한 반응(실패)
                else if(tokens[0] == "fail")
                {
                    //MessageBox.Show("전송 완료");

                    label1.Text = "[Fail] 숫자를 입력해 주세요!";

                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (recordView.Items.Count + 1).ToString();
                    lvi.SubItems.Add(tokens[2]);
                    lvi.SubItems.Add(tokens[1]);
                    recordView.Items.Add(lvi);

                    num1.Focus();
                }
                //(2-2) 보낸 답에 대한 반응(성공)
                else if (tokens[0] == "succ")
                {
                    //MessageBox.Show("전송 완료");

                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (recordView.Items.Count + 1).ToString();
                    lvi.SubItems.Add(tokens[2]);
                    lvi.SubItems.Add(tokens[1]);
                    recordView.Items.Add(lvi);

                    //숫자를 보내지 못하게 막는다
                    num1.ReadOnly = true;
                    num2.ReadOnly = true;
                    num3.ReadOnly = true;
                    num4.ReadOnly = true;

                    label1.Text = string.Format("[Success] {0} 회만에 성공했습니다!", recordView.Items.Count);
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

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!toServer.IsBound)
            {
                toServer.Close();
                return;
            }

            if (MessageBox.Show("정말 종료하시겠습니까?", "Exit",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                byte[] bDts = Encoding.UTF8.GetBytes("exit" + '\x01' + myclient + '\x01');
                
                toServer.Send(bDts);
                //toServer.BeginSend(bDts, 0, bDts.Length, SocketFlags.None, DataSend, toServer);

                toServer.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void sendData_Click(object sender, EventArgs e)
        {
            if (num1.Text.Length == 1 && num2.Text.Length == 1 && num3.Text.Length == 1 && num4.Text.Length == 1)
            {
                string answer = string.Format(num1.Text + '\x01' + num2.Text + '\x01' + num3.Text + '\x01' + num4.Text + '\x01' + recordView.Items.Count.ToString());
                byte[] bDts = Encoding.UTF8.GetBytes(string.Format("answer" + '\x01' + myclient + '\x01' + answer + '\x01'));

                toServer.Send(bDts);

                num1.Text = "";
                num2.Text = "";
                num3.Text = "";
                num4.Text = "";
            }
        }

        //Tab, Enter에 관한 이벤트이다
        private void num1_KeyDown(object sender, KeyEventArgs e)
        {
            //엔터 키를 누르면 번호 + 시도 횟수를 송신한다
            if (e.KeyCode == Keys.Enter)
            {
                if (num1.Text.Length == 1 && num2.Text.Length == 1 && num3.Text.Length == 1 && num4.Text.Length == 1)
                {
                    string answer = string.Format(num1.Text + '\x01' + num2.Text + '\x01' + num3.Text + '\x01' + num4.Text + '\x01' + recordView.Items.Count.ToString());
                    byte[] bDts = Encoding.UTF8.GetBytes(string.Format("answer" + '\x01' + myclient + '\x01' + answer + '\x01'));

                    toServer.Send(bDts);

                    num1.Text = "";
                    num2.Text = "";
                    num3.Text = "";
                    num4.Text = "";
                }
            }
        }

        private void num2_KeyDown(object sender, KeyEventArgs e)
        {
            //엔터 키를 누르면 번호 + 시도 횟수를 송신한다
            if (e.KeyCode == Keys.Enter)
            {
                if (num1.Text.Length == 1 && num2.Text.Length == 1 && num3.Text.Length == 1 && num4.Text.Length == 1)
                {
                    string answer = string.Format(num1.Text + '\x01' + num2.Text + '\x01' + num3.Text + '\x01' + num4.Text + '\x01' + recordView.Items.Count.ToString());
                    byte[] bDts = Encoding.UTF8.GetBytes(string.Format("answer" + '\x01' + myclient + '\x01' + answer + '\x01'));

                    toServer.Send(bDts);

                    num1.Text = "";
                    num2.Text = "";
                    num3.Text = "";
                    num4.Text = "";
                }
            }
        }

        private void num3_KeyDown(object sender, KeyEventArgs e)
        {
            //엔터 키를 누르면 번호 + 시도 횟수를 송신한다
            if (e.KeyCode == Keys.Enter)
            {
                if (num1.Text.Length == 1 && num2.Text.Length == 1 && num3.Text.Length == 1 && num4.Text.Length == 1)
                {
                    string answer = string.Format(num1.Text + '\x01' + num2.Text + '\x01' + num3.Text + '\x01' + num4.Text + '\x01' + recordView.Items.Count.ToString());
                    byte[] bDts = Encoding.UTF8.GetBytes(string.Format("answer" + '\x01' + myclient + '\x01' + answer + '\x01'));

                    toServer.Send(bDts);

                    num1.Text = "";
                    num2.Text = "";
                    num3.Text = "";
                    num4.Text = "";
                }
            }
        }

        private void num4_KeyDown(object sender, KeyEventArgs e)
        {
            //엔터 키를 누르면 번호 + 시도 횟수를 송신한다
            if (e.KeyCode == Keys.Enter)
            {
                if (num1.Text.Length == 1 && num2.Text.Length == 1 && num3.Text.Length == 1 && num4.Text.Length == 1)
                {
                    string answer = string.Format(num1.Text + '\x01' + num2.Text + '\x01' + num3.Text + '\x01' + num4.Text + '\x01' + recordView.Items.Count.ToString());
                    byte[] bDts = Encoding.UTF8.GetBytes(string.Format("answer" + '\x01' + myclient + '\x01' + answer + '\x01'));

                    toServer.Send(bDts);

                    num1.Text = "";
                    num2.Text = "";
                    num3.Text = "";
                    num4.Text = "";
                }
            }
        }

        //0~9까지만 입력할 수 있다
        private void num1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력 받을 수 있게 한다
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || (e.KeyChar == '.')))
            {
                e.Handled = true;
            }
        }

        private void num2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력 받을 수 있게 한다
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || (e.KeyChar == '.')))
            {
                e.Handled = true;
            }
        }

        private void num3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력 받을 수 있게 한다
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || (e.KeyChar == '.')))
            {
                e.Handled = true;
            }
        }

        private void num4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력 받을 수 있게 한다
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || (e.KeyChar == '.')))
            {
                e.Handled = true;
            }
        }
    }
}
