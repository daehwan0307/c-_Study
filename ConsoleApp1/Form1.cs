using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LibUsbDotNet;
using LibUsbDotNet.Info;
using LibUsbDotNet.Main;

namespace USB
{
    public partial class Form1 : Form
    {

        public static UsbDevice usbDevice;
        public static UsbRegistry [] usbRegistry;
        public static int nIdx;
        public UsbEndpointReader reader;
        delegate void txtBox(RichTextBox tb, string text);

        public Form1()
        {
            InitializeComponent();

            //컴퓨터에 연결된 USB 모든장치 로드
            UsbRegDeviceList allDevice = UsbDevice.AllDevices;
            usbRegistry = new UsbRegistry[allDevice.Count];

            int cntUsb = 0;
            //장치들을 하나씩 돌아가면서 조회
            foreach (UsbRegistry tmpUsbRegistry in allDevice)
            {
                //해당 USB가 정상적으로 열리면
                if(tmpUsbRegistry.Open(out usbDevice))
                {
                    //항목들을 하나씩 리스트박스에 추가
                    usbRegistry[cntUsb] = tmpUsbRegistry;
                    listBox1.Items.Add(usbRegistry[cntUsb].FullName);
                }
                cntUsb++;
            }

            UsbDevice.Exit();
        }


        public void setText(RichTextBox txt, string str)
        {
            if (richTextBox1.InvokeRequired)
            {
                txtBox ci = new txtBox(setText);
                richTextBox1.Invoke(ci, richTextBox1, str);
            }
            else
            {
                richTextBox1.Text =  str + "\r\n" + richTextBox1.Text;
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //리스트박스에서 선택된 USB 인덱스
            nIdx = ((System.Windows.Forms.ListBox)(sender)).SelectedIndex; 

            fldManufacturer.Text = (usbRegistry[nIdx].Device).Info.ManufacturerString;
            fldRev.Text = usbRegistry[nIdx].Rev.ToString();
            fldProduct.Text = (usbRegistry[nIdx].Device).Info.ProductString;
            fldSerial.Text = (usbRegistry[nIdx].Device).Info.SerialString;
            fldProductID.Text = usbRegistry[nIdx].Pid.ToString();
            fldVendorID.Text = usbRegistry[nIdx].Vid.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("연결된 USB가 없습니다.");
                return;
            }

            //데이터 수신 준비
            IUsbDevice wholeUsbDevice = usbDevice as IUsbDevice;
            
            //USB에서 들어오는 신호를 받기위해 EndPoint 설정
            reader = usbDevice.OpenEndpointReader(ReadEndpointID.Ep02);
            ReadEventinitStart();

            if (!ReferenceEquals(wholeUsbDevice, null))
            {
                wholeUsbDevice.SetConfiguration(1);
                wholeUsbDevice.ClaimInterface(0);
            }
        }

        public void ReadEvent(object sender, EndpointDataEventArgs e)
        {
            //USB에서 신호가 들어오면 활성화 되는 이벤트
            //string str = UnicodeEncoding.ASCII.GetString(e.Buffer, 0, e.Count);
            string str  = BitConverter.ToInt64(e.Buffer, 0).ToString();
            try
            {
                //받아온 데이터를 기록한다.
                setText(richTextBox1, str);

            }
            catch (System.Exception ex)
            {

            }
        }

        public void ReadEventinitStart()
        {
            //리더 활성화
            reader.DataReceivedEnabled = true;
            //이벤트 핸들러 연결
            reader.DataReceived += (ReadEvent);
        }

    }
}
