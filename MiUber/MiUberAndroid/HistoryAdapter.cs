using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using PCLCode.Entities;
using System.Collections.Generic;
using Android.App;

namespace MiUberAndroid
{
    public class HistoryAdapter : BaseAdapter<ViajeEjemplo>
    {
        List<ViajeEjemplo> Items; // Datos de cada evidencia de laboratorio.
        Activity Context; // Activity donde se utilizará este Adapter.
        int ItemLayoutTemplate; // Layout a utilizar para mostrar los datos de un elemento.
        int ViajeEjemploFechaInicioViewID; // ID del TextView donde se mostrará la fecha de inicio del viaje.
        int ViajeEjemploModeloAutoViewID; // ID del TextView donde se mostrará el modelo del auto.
        int ViajeEjemploPrecioViewID; /// ID del textView donde se mostrara el precio del viaje.
        /// <summary>
        /// Constructor para recibir la información que necesita el Adapter
        /// </summary>
        /// <param name="context">Activity donde se aloja el ListView.</param>
        /// <param name="evidences">La lista de elementos.</param>
        /// <param name="itemLayoutTemplate">ID del Layout para mostrar cada elemento del ListView.</param>
        /// <param name="evidenceTitleViewID">ID del TextView donde se mostrará el título de la evidencia.</param>
        /// <param name="evidenceStatusViewID">ID del TextView donde se mostrará el estatus de la evidencia.</param>
        public HistoryAdapter(Activity context, List<ViajeEjemplo> viajes, int itemLayoutTemplate, int viajeEjemploFechaInicioViewID, int viajeEjemploModeloAutoViewID, int viajeEjemploPrecioViewID)
        {
            this.Context = context;
            this.Items = viajes;
            this.ItemLayoutTemplate = itemLayoutTemplate;
            this.ViajeEjemploFechaInicioViewID = viajeEjemploFechaInicioViewID;
            this.ViajeEjemploModeloAutoViewID = viajeEjemploModeloAutoViewID;
            this.ViajeEjemploPrecioViewID = viajeEjemploPrecioViewID;
        }

        /// <summary>
        ///  Devuelve el elemento de la lista localizado en la posición especificada.
        /// </summary>
        /// <param name="position">Posición del elemento dentro de la lista.</param>
        /// <returns></returns>
        public override ViajeEjemplo this[int position]
        {
            get
            {
                return Items[position];
            }
        }

        /// <summary>
        /// Devuelve el número de elementos de la lista.
        /// </summary>
        public override int Count
        {
            get
            {
                return Items.Count;
            }
        }

        /// <summary>
        /// Devuelve el ID del elemento localizado en la posición especificada.
        /// </summary>
        /// <param name="position">Posición del elemento dentro de la lista.</param>
        /// <returns></returns>
        public override long GetItemId(int position)
        {
            return Items[position].id;
        }

        //  
        /// <summary>
        /// Devuelve el View que muestra los datos de un elemento del conjunto de datos.
        /// </summary>
        /// <param name="position">Posición del elemento a mostrar.</param>
        /// <param name="convertView">View anterior que puede ser reutilizada.</param>
        /// <param name="parent">View padre al que podria adjuntarse el View devuelto.</param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Obtenemos el elemento del cual se requiere la Vista
            var Item = Items[position];
            View ItemView; // Vista que vamos a devolver
            if (convertView == null)
            {
                // No hay vista reutilizable, crear una nueva
                ItemView = Context.LayoutInflater.Inflate(ItemLayoutTemplate, null /* No hay View padre*/);
            }
            else
            {
                // Reutilizamos un View existente para ahorrar recursos
                ItemView = convertView;
            }

            // Establecemos los datos del elemento dentro del View
            ItemView.FindViewById<TextView>(ViajeEjemploFechaInicioViewID).Text = Item.fechaInicio;
            ItemView.FindViewById<TextView>(ViajeEjemploModeloAutoViewID).Text = Item.modeloAuto;
            ItemView.FindViewById<TextView>(ViajeEjemploPrecioViewID).Text = Item.costo;

            return ItemView;
        }

    }
}