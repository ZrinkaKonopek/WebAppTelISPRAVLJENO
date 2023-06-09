using WebAppTel.Controllers;

namespace WebAppTel.Models
{
    public interface IRepozitorijUpita
    {
        IEnumerable<Mobitel> PopisMobitel();
        void Create(Mobitel mobitel);
        void Delete(Mobitel mobitel);
        void Update(Mobitel mobitel);

        int SljedeciId();
        int MarkaSljedeciId();
        Mobitel DohvatiMobitelSIdom(int id);

        IEnumerable<Marka> PopisMarka();
        void Create(Marka marka);
        void Delete(Marka marka);
        void Update(Marka marka);  
        Marka DohvatiMarkuSIdom(int id);
    }
}
