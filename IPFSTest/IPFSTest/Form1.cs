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

namespace IPFSTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {           
            //CancellationToken cancel;

            //Process process = Process.Start("cmd.EXE");
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = @"C:\go-ipfs\ipfs.EXE";
            //startInfo.WorkingDirectory = @"C:\go-ipfs";

            //startInfo.Arguments = "ipfs init -f";
            //Process.Start(startInfo);

            //startInfo.Arguments = "ipfs daemon";
            //Process.Start(startInfo);
            
            var ipfs = new IpfsClient();
            //var b = await ipfs.DoCommandAsync("swarm/peers",cancel);
            //richTextBox2.Text = ipfs.Swarm.ToString();
            //var c = await ipfs.DoCommandAsync("daemon", cancel);
            //var a = await ipfs.FileSystem.ReadAllTextAsync("aa.txt");
           
            //const string filename = "/ipfs/QmS4ustL54uo8FzR9455qaxZwuMiUhyvMcX9Ba8nUH4uVv/readme";
            //string text = await ipfs.FileSystem.ReadAllTextAsync(filename);
            //richTextBox1.Text = text;
            /**
            string fileName = @"C:\go-ipfs\hello.txt";
            File.WriteAllText(fileName, "hello world 2");
            var path = Path.GetFileName(fileName);
           
            var aaa = ipfs.FileSystem.AddFileAsync(path);
            var txt2 = aaa.Result;
            
            richTextBox2.Text = txt2.ToString();
            */

            //string fileName2 = @"C:\go-ipfs\hello.txt";
            //Stream stream = File.Open(fileName2, FileMode.Open);
            //var aaa = await ipfs.FileSystem.AddAsync(stream, "ipfstest");
            //richTextBox1.Text = await ipfs.FileSystem.ReadAllTextAsync(aaa.Id.Hash.ToString());

            //var service = new IpfsService("https://ipfs.infura.io:5001");
            //var node = service.AddFileAsync(@"C:\go-ipfs\hello.txt").Result;
            //var hash = node.Hash.ToString();
            //Process.Start("https://ipfs.infura.io/ipfs/" + hash);
            //Console.ReadLine();

            //const string filename = "QmXarR6rgkQ2fDSHjSY5nM2kuCXKYGViky5nohtwgF65Ec/about";
            //string text = await ipfs.FileSystem.ReadAllTextAsync(filename);

            /**
            string fileName = @"C:\go-ipfs\testme.txt";
            File.WriteAllText(fileName, "hello world 2");
            var path = Path.GetFileName(fileName);
            var ipfs2 = new IpfsClient();
            var aaa = ipfs2.FileSystem.AddFileAsync(path);
            var txt2 = aaa.Result;
            Console.WriteLine(txt2);
            textBox1.Text = txt2.ToString();
            */
            //var ipfs = new IpfsClient();
            //read readme.txt 
            //string filename1 = "QmS4ustL54uo8FzR9455qaxZwuMiUhyvMcX9Ba8nUH4uVv/about";
            //string text1 = await ipfs.FileSystem.ReadAllTextAsync(filename1);
            //richTextBox1.Text = text;
            // add ipfs-test.txt in ipfs, then read the uploaded file using this file's ipfs address/hash 
            string fileName2 = @"C:\go-ipfs\hello.txt";
            
            Stream stream = File.Open(fileName2, FileMode.Open);
            
            var aaa = await ipfs.FileSystem.AddAsync(stream, "ipfstest");
            richTextBox1.Text = await ipfs.FileSystem.ReadAllTextAsync(aaa.Id.Hash.ToString());
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.Message;
            }
        }

        /**
        public class IpfsService
        {

            private string ipfsUrl;
            public IpfsService(string ipfsUrl)
            {
                this.ipfsUrl = ipfsUrl;
            }

            public async Task<MerkleNode> AddFileAsync(string filePath)
            {
                var fileName = Path.GetFileName(filePath);
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    return await AddAsync(fileName, fileStream).ConfigureAwait(false);
                }
            }

            public async Task<MerkleNode> AddAsync(string name, Stream stream)
            {
                
                using (var ipfs = new IpfsClient())
                {
                    var inputStream = new IpfsStream(name, stream);

                    var merkleNode = await ipfs.Add(inputStream).ConfigureAwait(false);
                    var multiHash = ipfs.Pin.Add(merkleNode.Hash.ToString());
                    return merkleNode;
                }
            }

            public async Task<HttpContent> PinListAsync()
            {
                using (var ipfs = new IpfsClient(ipfsUrl))
                {
                    return await ipfs.Pin.Ls();
                }
            }
        } */
    }
}
