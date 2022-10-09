using System;
using System.Collections.Generic;

namespace LogicaAplicacion.InterfacesCasosUso
{
    public interface IListado<T>
    {

        IEnumerable<T> ObtenerListado();
        
    }
}
