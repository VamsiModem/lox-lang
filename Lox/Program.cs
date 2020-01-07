using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lox
{
    class Program
    {
        static bool hadError = false;
        public static void Main(string[] args) 
        {
            if(args.Length > 1){
                Console.WriteLine("Usage: cslox [script]");
                System.Environment.Exit(0);
            }else if(args.Length == 1){ RunFile(args[0]); }
            else{ RunPrompt(); }
        }

        private static void RunFile(string path){
            byte[] bytes = File.ReadAllBytes(path);
            Run(bytes);
            if(hadError){System.Environment.Exit(0);}
        }

        private static void Run(string source){
            Scanner scanner = new Scanner(source);
            List<Token> tokens = scanner.ScanTokens();
            foreach(Token token in tokens){
                Console.WriteLine(token);
            }
        }

        private static void Run(byte[] source){
            Run(Encoding.Default.GetString(source));
        }

        private static void RunPrompt(){
            using (StreamReader sr = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding))
            {
                Console.WriteLine(">>");
                Run(sr.ReadLine());
                hadError = false;
            }
            RunPrompt();
        }

        static void Error(int line, string messsage){
            Report(line, string.Empty, messsage);
        }

        private static void Report(int line, string where, string message){
            Console.Error.WriteLine("[line " + line + "] Error" + where + ": " + message);
            hadError = true;
        }
    }
}
