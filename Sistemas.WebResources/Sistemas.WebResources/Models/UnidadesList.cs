using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas.WebResources.Models
{
    public class UnidadesList : List<Unidad>
    {
        public UnidadesList()
        {
            this.Add(new Unidad() { Id = 1, Nemonico = "KG", Descripcion = "Kilogramo" });
            this.Add(new Unidad() { Id = 2, Nemonico = "LT", Descripcion = "Litro" });
            this.Add(new Unidad() { Id = 3, Nemonico = "MT", Descripcion = "Metro" });
            this.Add(new Unidad() { Id = 4, Nemonico = "GL", Descripcion = "Galón" });
            this.Add(new Unidad() { Id = 5, Nemonico = "UN", Descripcion = "Unidad" });
            this.Add(new Unidad() { Id = 6, Nemonico = "CJ", Descripcion = "Caja" });
        }

        public void AddItem(Unidad unidad)
        {
            int maxIndex = this.Max(x => x.Id) + 1;
            unidad.Id = maxIndex;
            this.Add(unidad);
        }
    }

    public class Unidades
    {
        private static Unidades instance;

        public  UnidadesList Lista { get; set; }


        private Unidades()
        {
            this.Lista = new UnidadesList();
        }


        public static Unidades Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Unidades();
                }
                return instance;
            }
        }

    }
}
