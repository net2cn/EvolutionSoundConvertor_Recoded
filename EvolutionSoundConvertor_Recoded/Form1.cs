/*
 * TODO:
 * 1.Optimize code
 * 2.Convert all sounds to .wav files
 * 3.Multi-threading.
*/
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace EvolutionSoundConvertor_Recoded
{
    public partial class Form1 : Form
    {
        private const string SETTINGSSAVENAME = "settings.ini";
        private int bfile;
        private string bname;
        private int bsize;
        private int datasize;

        private readonly StreamWriter errorLogWriter = new StreamWriter("errors.log");
        private string fname;
        private int gameSelection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (File.Exists(SETTINGSSAVENAME))
                try
                {
                    var streamReader = new StreamReader(SETTINGSSAVENAME);
                    H_dir.Text = streamReader.ReadLine();
                    B_dir.Text = streamReader.ReadLine();
                    F_dir.Text = streamReader.ReadLine();
                    outputDir.Text = streamReader.ReadLine();
                    gameSelector.SelectedIndex = int.Parse(streamReader.ReadLine());
                    streamReader.Close();
                }
                catch
                {
                }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var streamWriter = new StreamWriter(SETTINGSSAVENAME);
            streamWriter.WriteLine(H_dir.Text);
            streamWriter.WriteLine(B_dir.Text);
            streamWriter.WriteLine(F_dir.Text);
            streamWriter.WriteLine(outputDir.Text);
            streamWriter.WriteLine(gameSelector.SelectedIndex);
            streamWriter.Close();
        }

        private void H_dirSelector_Click(object sender, EventArgs e)
        {
            H_dir.Text = SelectFolder("H");
        }

        private void B_dirSelector_Click(object sender, EventArgs e)
        {
            B_dir.Text = SelectFolder("B");
        }

        private void F_dirSelector_Click(object sender, EventArgs e)
        {
            F_dir.Text = SelectFolder("F");
        }

        private void OutputSelector_Click(object sender, EventArgs e)
        {
            outputDir.Text = SelectFolder("Output");
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if (gameSelector.SelectedIndex != -1)
                if (!Directory.Exists(H_dir.Text))
                {
                    MessageBox.Show("Invaild H Files Folder!", "Error!", 0, MessageBoxIcon.Error);
                }
                else if (!Directory.Exists(B_dir.Text))
                {
                    MessageBox.Show("Invaild B Files Folder!", "Error!", 0, MessageBoxIcon.Error);
                }
                else if (!Directory.Exists(F_dir.Text))
                {
                    MessageBox.Show("Invaild F Files Folder!", "Error!", 0, MessageBoxIcon.Error);
                }
                else if (!Directory.Exists(outputDir.Text))
                {
                    MessageBox.Show("Invaild Output Files Folder!", "Error!", 0, MessageBoxIcon.Error);
                }
                else
                {
                    gameSelection = gameSelector.SelectedIndex;
                    var converting = new Thread(StartConvert) {IsBackground = true};
                    converting.Start();
                }
            else
                MessageBox.Show("Please select a game.", "Error!", 0, MessageBoxIcon.Error);
        }

        private string SelectFolder(string fileType)
        {
            var dialog = new FolderBrowserDialog {Description = "Select " + fileType + " Files Folder"};
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.SelectedPath;
            return null;
        }

        private void StartConvert()
        {
            var directoryInfo = new DirectoryInfo(H_dir.Text);
            var num1 = 0;
            var num2 = 0;
            var num3 = 0;
            var num4 = 0;

            progressBar1.Invoke((MethodInvoker) delegate { progressBar1.Style = ProgressBarStyle.Marquee; });
            //Notice: "H" is file's header, "B" is corresponding binary files(not for sounds), "F" is full sound. (According to http://forum.xentax.com/viewtopic.php?t=10782)
            foreach (var file in directoryInfo.GetFiles("*.wav", SearchOption.AllDirectories))
            {
                var fileStream = new FileStream(file.FullName, FileMode.Open);
                var binaryReader = new BinaryReader(fileStream);
                bname = file.FullName.Replace(H_dir.Text, B_dir.Text);
                fname = file.FullName.Replace(H_dir.Text, F_dir.Text);

                if (gameSelection > 2)
                    fileStream.Seek(16L, SeekOrigin.Current);
                var num5 = binaryReader.ReadInt32();
                for (var index = 0; index < num5; ++index)
                {
                    var num6 = binaryReader.ReadInt32();
                    fileStream.Seek(num6, SeekOrigin.Current);
                }
                var num7 = binaryReader.ReadInt32();
                if (num7 > 0)
                    fileStream.Seek(num7 + 1, SeekOrigin.Current);
                var num8 = binaryReader.ReadInt32();
                if (num8 < 128 || num8 > 136)
                {
                    MessageBox.Show("Bad format. 0x80 expected.");
                }
                else
                {
                    if (!Directory.Exists(file.DirectoryName.Replace(H_dir.Text, outputDir.Text)))
                        Directory.CreateDirectory(file.DirectoryName.Replace(H_dir.Text, outputDir.Text));
                    var num6 = binaryReader.ReadInt32();
                    switch (num6)
                    {
                        case 0:
                            ++num1;
                            fileStream.Seek(24L, SeekOrigin.Current);
                            bfile = binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            var num10 = binaryReader.ReadInt32();
                            int num11 = binaryReader.ReadByte();
                            int num12 = binaryReader.ReadByte();
                            binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            datasize = binaryReader.ReadInt32();
                            var fw1 = new FileStream(file.FullName.Replace(H_dir.Text, outputDir.Text), FileMode.Create);
                            var binaryWriter1 = new BinaryWriter(fw1);
                            binaryWriter1.Write('R');
                            binaryWriter1.Write('I');
                            binaryWriter1.Write('F');
                            binaryWriter1.Write('F');
                            binaryWriter1.Write(datasize + 36);
                            binaryWriter1.Write('W');
                            binaryWriter1.Write('A');
                            binaryWriter1.Write('V');
                            binaryWriter1.Write('E');
                            binaryWriter1.Write('f');
                            binaryWriter1.Write('m');
                            binaryWriter1.Write('t');
                            binaryWriter1.Write(' ');
                            binaryWriter1.Write(16);
                            binaryWriter1.Write((short) 1);
                            binaryWriter1.Write((short) num12);
                            binaryWriter1.Write(num10);
                            binaryWriter1.Write(num10 * num12 * num11 / 8);
                            binaryWriter1.Write((short) (num12 * num11 / 8));
                            binaryWriter1.Write((short) num11);
                            binaryWriter1.Write('d');
                            binaryWriter1.Write('a');
                            binaryWriter1.Write('t');
                            binaryWriter1.Write('a');
                            binaryWriter1.Write(datasize);
                            if (gameSelection > 2)
                                fileStream.Seek(8L, SeekOrigin.Current);
                            fileStream.Seek(21L, SeekOrigin.Current);
                            bsize = binaryReader.ReadInt32();
                            Writedata(fw1);
                            binaryWriter1.Close();
                            fw1.Close();
                            break;
                        case 1:
                            ++num3;
                            fileStream.Seek(24L, SeekOrigin.Current);
                            bfile = binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            var num13 = binaryReader.ReadInt32();
                            int num14 = binaryReader.ReadByte();
                            int num15 = binaryReader.ReadByte();
                            binaryReader.ReadInt32();
                            var num16 = binaryReader.ReadInt32();
                            var num17 = binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            datasize = binaryReader.ReadInt32();
                            var path = file.FullName.Replace(H_dir.Text, outputDir.Text);
                            var fw2 =
                                new FileStream(
                                    Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) +
                                    ".xwma", FileMode.Create);
                            var binaryWriter2 = new BinaryWriter(fw2);
                            binaryWriter2.Write('R');
                            binaryWriter2.Write('I');
                            binaryWriter2.Write('F');
                            binaryWriter2.Write('F');
                            binaryWriter2.Write(datasize + 50);
                            binaryWriter2.Write('X');
                            binaryWriter2.Write('W');
                            binaryWriter2.Write('M');
                            binaryWriter2.Write('A');
                            binaryWriter2.Write('f');
                            binaryWriter2.Write('m');
                            binaryWriter2.Write('t');
                            binaryWriter2.Write(' ');
                            binaryWriter2.Write(18);
                            binaryWriter2.Write((short) 353);
                            binaryWriter2.Write((short) num15);
                            binaryWriter2.Write(num13);
                            binaryWriter2.Write(num16);
                            binaryWriter2.Write((short) num17);
                            binaryWriter2.Write(num14);
                            binaryWriter2.Write('d');
                            binaryWriter2.Write('p');
                            binaryWriter2.Write('d');
                            binaryWriter2.Write('s');
                            binaryWriter2.Write(4);
                            binaryWriter2.Write(0);
                            binaryWriter2.Write('d');
                            binaryWriter2.Write('a');
                            binaryWriter2.Write('t');
                            binaryWriter2.Write('a');
                            binaryWriter2.Write(datasize);
                            if (gameSelection > 2)
                                fileStream.Seek(8L, SeekOrigin.Current);
                            fileStream.Seek(21L, SeekOrigin.Current);
                            bsize = binaryReader.ReadInt32();
                            Writedata(fw2);
                            binaryWriter2.Close();
                            fw2.Close();
                            break;
                        case 5:
                            var numArray = new short[]
                            {
                                256,
                                0,
                                512,
                                -256,
                                0,
                                0,
                                192,
                                64,
                                240,
                                0,
                                460,
                                -208,
                                392,
                                -232
                            };
                            ++num2;
                            fileStream.Seek(24L, SeekOrigin.Current);
                            bfile = binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            var num18 = binaryReader.ReadInt32();
                            int num19 = binaryReader.ReadByte();
                            int num20 = binaryReader.ReadByte();
                            binaryReader.ReadInt32();
                            var num21 = binaryReader.ReadInt32();
                            int num22 = binaryReader.ReadInt16();
                            int num23 = binaryReader.ReadInt16();
                            binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            binaryReader.ReadInt32();
                            datasize = binaryReader.ReadInt32();
                            var fw3 = new FileStream(file.FullName.Replace(H_dir.Text, outputDir.Text), FileMode.Create);
                            var binaryWriter3 = new BinaryWriter(fw3);
                            binaryWriter3.Write('R');
                            binaryWriter3.Write('I');
                            binaryWriter3.Write('F');
                            binaryWriter3.Write('F');
                            binaryWriter3.Write(datasize + 70);
                            binaryWriter3.Write('W');
                            binaryWriter3.Write('A');
                            binaryWriter3.Write('V');
                            binaryWriter3.Write('E');
                            binaryWriter3.Write('f');
                            binaryWriter3.Write('m');
                            binaryWriter3.Write('t');
                            binaryWriter3.Write(' ');
                            binaryWriter3.Write(50);
                            binaryWriter3.Write((short) 2);
                            binaryWriter3.Write((short) num20);
                            binaryWriter3.Write(num18);
                            binaryWriter3.Write(num21);
                            binaryWriter3.Write((short) num22);
                            binaryWriter3.Write((short) num19);
                            binaryWriter3.Write((short) 32);
                            binaryWriter3.Write((short) num23);
                            binaryWriter3.Write((short) 7);
                            for (var index = 0; index < 14; ++index)
                                binaryWriter3.Write(numArray[index]);
                            binaryWriter3.Write('d');
                            binaryWriter3.Write('a');
                            binaryWriter3.Write('t');
                            binaryWriter3.Write('a');
                            binaryWriter3.Write(datasize);
                            if (gameSelection > 2)
                                fileStream.Seek(8L, SeekOrigin.Current);
                            fileStream.Seek(21L, SeekOrigin.Current);
                            bsize = binaryReader.ReadInt32();
                            Writedata(fw3);
                            binaryWriter3.Close();
                            fw3.Close();
                            break;
                        default:
                            ++num4;
                            MessageBox.Show("Unknown codec " + num6);
                            break;
                    }
                    binaryReader.Close();
                    fileStream.Close();
                }
            }
            progressBar1.Invoke((MethodInvoker) delegate
            {
                progressBar1.Value = 100;
                progressBar1.Style = ProgressBarStyle.Blocks;
            });
            MessageBox.Show("File(s) converted successfully. PCM: " + num1 + ", ADPCM: " + num2 + ", xWMA: " + num3 +
                            ", error(s) has logged in errors.log");
        }

        private void Writedata(FileStream fw)
        {
            FileStream fileStream1 = null;
            if (bfile != 0)
                fileStream1 = new FileStream(fname, FileMode.Open);
            if (bfile != 2)
            {
                var datasize = this.datasize;
                if (bfile != 0)
                    datasize -= (int) fileStream1.Length;
                var fileStream2 = new FileStream(bname, FileMode.Open);
                if (datasize != fileStream2.Length)
                    try
                    {
                        fileStream2.Seek(-datasize, SeekOrigin.End);
                    }
                    catch
                    {
                        errorLogWriter.WriteLine(DateTime.Now + " (Write Error) " + fname);
                    }
                var buffer = new byte[datasize];
                fileStream2.Read(buffer, 0, buffer.Length);
                fileStream2.Close();
                fw.Write(buffer, 0, buffer.Length);
            }
            if (bfile == 0)
                return;
            var buffer1 = new byte[fileStream1.Length];
            fileStream1.Read(buffer1, 0, buffer1.Length);
            fileStream1.Close();
            fw.Write(buffer1, 0, buffer1.Length);
        }
    }
}