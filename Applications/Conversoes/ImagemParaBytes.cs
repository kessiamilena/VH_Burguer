namespace VHBurguer.Applications.Conversoes
{
    public class ImagemParaBytes
    {
        public static byte[] ConverterImagem(IFormFile imagem)
        {
            using var ms = new MemoryStream();
            imagem.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
