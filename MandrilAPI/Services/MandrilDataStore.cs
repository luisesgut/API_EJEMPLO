using MandrilAPI.Models;

namespace MandrilAPI.Services;

public class MandrilDataStore
{
    public List<Mandril> Mandriles { get; set; }

    public static MandrilDataStore current { get; } = new MandrilDataStore();
    public MandrilDataStore()
    {
        Mandriles = new List<Mandril>()
        {
            new Mandril
            {
                Id = 1,
                Nombre = "Mandrilo",
                Apellido = "Mandrilez",
                Habilidades = new List<Habilidad>
                {
                    new Habilidad
                    {
                        Id = 1,
                        Nombre = "Saltar",
                        Potencia = Habilidad.Epotencia.Suave
                    },
                    new Habilidad
                    {
                        Id = 2,
                        Nombre = "Correr",
                        Potencia = Habilidad.Epotencia.Moderado
                    }
                }
            },
            new Mandril
            {
                Id = 2,
                Nombre = "Mandrila",
                Apellido = "Mandrilez",
                Habilidades = new List<Habilidad>
                {
                    new Habilidad
                    {
                        Id = 1,
                        Nombre = "Saltar",
                        Potencia = Habilidad.Epotencia.Suave
                    },
                    new Habilidad
                    {
                        Id = 2,
                        Nombre = "Correr",
                        Potencia = Habilidad.Epotencia.Moderado
                    }
                }
            }
        };
    }
}
