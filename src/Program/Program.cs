using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {  
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            IPipe nulo = new PipeNull();
            IFilter negativo = new FilterNegative();
            IPipe primerserial = new PipeSerial(negativo,nulo);
            IFilter gris = new FilterGreyscale();
            IPipe segundoserial = new PipeSerial(gris, primerserial);
            IPicture final = segundoserial.Send(picture);
            provider.SavePicture(final, @"save.jpg");
        }
    }
}
