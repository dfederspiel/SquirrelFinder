using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquirrelFinder.Nuts;

namespace SquirrelFinder
{
    public interface INutManager
    {
        event EventHandler<NutEventArgs> NutChanged;
        event EventHandler<NutCollectionEventArgs> NutCollectionChanged;

        void AddNut(INut nut);
        void RemoveNut(INut nut);

        void OnNutChanged(NutEventArgs e);
        void OnNutCollectionChanged(NutCollectionEventArgs e);

        Task PeekAllNuts();
    }
}