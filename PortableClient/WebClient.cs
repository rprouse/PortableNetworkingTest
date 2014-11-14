using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace PortableClient
{
    public interface IRenderer
    {
        void RenderStream( Stream stream );
    }

    public class WebClient
    {
        private readonly IRenderer _renderer;

        public WebClient( IRenderer renderer )
        {
            _renderer = renderer;
        }

        public void HttpGet( string url )
        {
            WebRequest request = WebRequest.Create( url );

            request.BeginGetResponse( state =>
            {
                var webRequest = state.AsyncState as HttpWebRequest;
                if ( webRequest == null ) return;

                try
                {
                    WebResponse response = webRequest.EndGetResponse( state );
                    _renderer.RenderStream( response.GetResponseStream() );
                }
                catch ( Exception e )
                {
                    Debug.WriteLine( e );
                }

            }, request );
        }
    }
}
