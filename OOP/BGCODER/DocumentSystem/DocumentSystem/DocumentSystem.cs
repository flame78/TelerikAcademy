using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentSystem
{
    public class DocumentSystem
    {
        static List<Document> documents;

        [STAThreadAttribute]
        public static void Main()
        {
//            var input = new StringReader(@"AddTextDocument[name=example.txt;charset=utf-8;content=Telerik Academy Exam]
//AddTextDocument[name=readme.txt]
//AddTextDocument[]
//EncryptAllDocuments[]
//AddPDFDocument[content=6A7E889CF3A8D2;name=academy.pdf;pages=2;size=38217]
//AddWordDocument[name=exam.docx;chars=12218;version=2012;size=36881]
//AddWordDocument[name=exam.docx]
//AddExcelDocument[name=academy.xls;rows=12;cols=3;size=9430;version=97]
//AddAudioDocument[size=9834733;name=ring.mp3;samplerate=44100;length=368800]
//AddVideoDocument[name=demo.mpg;framerate=24;length=87312;size=87245212]
//EncryptDocument[academy.pdf]
//EncryptDocument[ring.mp3]
//EncryptDocument[exam.docx]
//EncryptDocument[invalid.doc]
//ChangeContent[example.txt;new content]
//ChangeContent[demo.mpg;new content]
//ChangeContent[invalid.doc;new content]
//EncryptAllDocuments[]
//DecryptDocument[academy.pdf]
//DecryptDocument[exam.docx]
//DecryptDocument[ring.mp3]
//DecryptDocument[invalid.doc]
//ListDocuments[]
//
//");
//            Console.SetIn(input);
//            var output = new StringWriter();
//            using (output)
//            {
//                Console.SetOut(output); 
            
            documents=new List<Document>();
                IList<string> allCommands = ReadAllCommands();
                ExecuteCommands(allCommands);

            //    System.Windows.Forms.Clipboard.SetText(output.ToString());
            //}

            
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddDocument(Document doc, string[] attributes)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            string name = "";
            foreach (var item in attributes)
            {
                var tokens = item.Split('=');
                if (tokens[0] == "name")
                {
                    name = tokens[1];
                    Console.WriteLine("Document added: " + name);
                    properties.Add(tokens[0], tokens[1]);
                }
                else properties.Add(tokens[0], tokens[1]);
            }

            if (name == "")
            {
                Console.WriteLine("Document has no name");
                return;
            }

            foreach (var item in properties)
            {
                doc.LoadProperty(item.Key, item.Value);
            }

            documents.Add(doc);
        }
        private static void AddTextDocument(string[] attributes)
        {
            AddDocument(new TextDocument(), attributes);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddDocument(new PDFDocument(), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddDocument(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddDocument(new ExcelDocument(), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddDocument(new AudioDocument(), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddDocument(new VideoDocument(), attributes);
        }

        private static void ListDocuments()
        {
            if (documents.Count == 0) Console.WriteLine("No documents found");
            foreach (var item in documents)
            {
                Console.WriteLine(item);
            }
        }

        private static void EncryptDocument(string name)
        {
            bool notFound=true;
            foreach (var item in documents.Where(a=> a.Name==name))
            {
                notFound = false;
                if (item is IEncryptable)
                {
                    var doc = item as IEncryptable;
                    doc.Encrypt();
                    Console.WriteLine("Document encrypted: " + name);
                }
                else
                { 
                    Console.WriteLine("Document does not support encryption: "+name);
                }

            }
            if (notFound) Console.WriteLine("Document not found: " + name);
            
        }

        private static void DecryptDocument(string name)
        {
            bool notFound = true;
            foreach (var item in documents.Where(a => a.Name == name))
            {
                notFound = false;
                if (item is IEncryptable)
                {
                    var doc = item as IEncryptable;
                    doc.Decrypt();
                    Console.WriteLine("Document decrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + name);
                }

            }
            if (notFound) Console.WriteLine("Document not found: " + name);
            
        }

        private static void EncryptAllDocuments()
        {
            bool notFound = true;
            foreach (var item in documents)
            {
                 if (item is IEncryptable)
                {
                    var doc = item as IEncryptable;
                    doc.Encrypt();
                    notFound = false;
                }
                

            }
            if (notFound) Console.WriteLine("No encryptable documents found");
            else Console.WriteLine("All documents encrypted");
            
        }

        private static void ChangeContent(string name, string content)
        {
            bool notFound = true;
            foreach (var item in documents.Where(a => a.Name == name))
            {
                notFound = false;
                if (item is IEditable)
                {
                    var doc = item as IEditable;
                    doc.ChangeContent(content);
                    Console.WriteLine("Document content changed: " + name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + name);
                }

            }
            if (notFound) Console.WriteLine("Document not found: " + name);
            
        }
    }
}