using System;

namespace inheritence
{
    class Canlilar
    {
        protected void Beslenme()
        {
            Console.WriteLine("Canlilar beslenir");
        }
        protected void Solunum()
        {
            Console.WriteLine("Canlilar solunum yapar");
        }
        protected void Bosaltim()
        {
            Console.WriteLine("Canlilar bosaltim yapar");
        }

        public virtual void UyaranlaraTepki()
        {
            Console.WriteLine("Canlilar uyaranlara tepki verir");
        }
    }
}