using System;
using System.IO;
using PortableClient;

namespace NetworkClient
{
    class ConsoleRenderer : IRenderer
    {
        #region Implementation of IRenderer

        public void RenderStream( Stream stream )
        {
            using ( var reader = new StreamReader( stream ) )
            {
                Console.Write( reader.ReadToEnd() );
            }
        }

        #endregion
    }

    class Program
    {
        static void Main( string[] args )
        {
            var client = new WebClient( new ConsoleRenderer() );
            client.HttpGet( @"http://www.alteridem.net/" );

            Console.WriteLine("*** Waiting for response ***");
            Console.ReadLine();
        }
    }
}
