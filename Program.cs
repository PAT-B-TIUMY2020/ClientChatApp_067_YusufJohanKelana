using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientChatApp_20180140067_Yusuf_Johan_Kelana
{
    class Program
    {
        // Sebagai context atau channel
        public class ClientCallback : ServiceReference1.IServiceCallbackCallback
        {
            public void pesanKirim(string user, string pesan)
            {
                Console.WriteLine("{0}: {1}", user, pesan);
            }
        }

        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new ClientCallback());
            ServiceReference1.ServiceCallbackClient server = new ServiceReference1.ServiceCallbackClient(context);

            Console.WriteLine("Masukkan username");
            string nama = Console.ReadLine();
            server.gabung(nama);

            Console.WriteLine("Kirim pesan");
            string pesan = Console.ReadLine();

            // Memeriksa apakah pesannya null
            while (true)
            {
                if (!string.IsNullOrEmpty(pesan))
                    server.kirimPesan(pesan);
                Console.WriteLine("Kirim Pesan");
                pesan = Console.ReadLine();
            }
        }
    }
}
