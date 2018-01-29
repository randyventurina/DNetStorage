using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Ipfs;
using Ipfs.Api;
//using Ipfs.CoreApi;
//using Ipfs.Commands;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
//using Ipfs;

namespace IPFSTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string x;
        public async void button1_Click(object sender, EventArgs e)
        {
            CancellationToken cancel;

            var ipfs = new IpfsClient();
            const string filename = "/ipfs/QmS4ustL54uo8FzR9455qaxZwuMiUhyvMcX9Ba8nUH4uVv/readme";
            string text = await ipfs.FileSystem.ReadAllTextAsync(filename);
            richTextBox1.Text = text;
            
            string fileName2 = @"C:\go-ipfs\hello.txt";
            File.WriteAllText(fileName2, "hello world 2");
            Stream stream = File.Open(fileName2, FileMode.Open);
            
            var aaa = await ipfs.FileSystem.AddAsync(stream, "trist");
            x = aaa.Id.Hash.ToString();
            string x2 = aaa.ToLink("trist").Name.ToString();
            richTextBox2.Text = await ipfs.FileSystem.ReadAllTextAsync(aaa.Id.Hash.ToString());
            richTextBox3.Text = "/" + aaa.Id.GetHashCode();
           
            /**
            using (var ipfs = new Ipfs.IpfsClient())
            {
                //Name of the file to add
                string fileName = @"C:\go-ipfs\hello.txt";

                //Wrap our stream in an IpfsStream, so it has a file name.
                Ipfs.IpfsStream inputStream = new Ipfs.IpfsStream(fileName, File.OpenRead(fileName));

                Ipfs.MerkleNode node = await ipfs.Add(inputStream);

                Stream outputStream = await ipfs.Cat(node.Hash.ToString());

                using (StreamReader sr = new StreamReader(outputStream))
                {
                    string contents = sr.ReadToEnd();
                    richTextBox2.Text = contents;
                    //Console.WriteLine(contents); //Contents of test.txt are printed here!
                }
            }*/

        }

        public async void button2_Click(object sender, EventArgs e)
        {
            CancellationToken cancel;
            var ipfs = new IpfsClient();
          
            var json = await ipfs.DoCommandAsync("files/rm", cancel, "/" + x);

            richTextBox3.Text = "/" + aaa.Id.GetHashCode();
            //richTextBox4.Text = x2;
            var x3 = await ipfs.Key.RemoveAsync(aaa.Id.GetHashCode().ToString());
            //var bbb = await ipfs.FileSystem.ListFileAsync(aaa.Id.Hash.ToString());
            //richTextBox3.Text = await ipfs.FileSystem.ReadAllTextAsync(aaa.Id.Hash.ToString());
            //richTextBox3.Text = bbb.ToString();         
            richTextBox4.Text = await ipfs.FileSystem.ReadAllTextAsync(aaa.Id.Hash.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Process process = Process.Start("cmd.EXE");
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = @"C:\go-ipfs\ipfs.EXE";
            //startInfo.WorkingDirectory = @"C:\go-ipfs";

            //startInfo.Arguments = "ipfs init -f";
            //Process.Start(startInfo);

            //startInfo.Arguments = "ipfs daemon";
            //Process.Start(startInfo);


            //var b = await ipfs.DoCommandAsync("swarm/peers",cancel);
            //richTextBox2.Text = ipfs.Swarm.ToString();
            //var c = await ipfs.DoCommandAsync("daemon", cancel);
            //var a = await ipfs.FileSystem.ReadAllTextAsync("aa.txt");
        }
    }
}
