using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"C:\Users\guill\Desktop\Pipes Filters1\PipesFilters1\src\Program\beer.jpg");
            IPipe nulo = new PipeNull();
            IFilter negativo = new FilterNegative();
            IPipe primerserial = new PipeSerial(negativo,nulo);
            IFilter gris = new FilterGreyscale();
            IPipe segundoserial = new PipeSerial(gris, primerserial);
            IPicture final = segundoserial.Send(picture);
            negativo.Publicar(picture);
            gris.Publicar(picture);
            provider.SavePicture(final, @"C:\Users\guill\Desktop\Pipes Filters1\PipesFilters1\src\Program\save.jpg");
        }
    }
}
