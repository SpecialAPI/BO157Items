using System;
using System.Collections.Generic;
using System.Text;

namespace BO157Items.Effect
{
    public class AddEntryToStoreDataHashSetEffect : AddEntryToStoreDataCollectionEffect<HashSet<int>>
    {
        public static EffectSO Create(string storedValue, bool usePreviousExit) => Create<AddEntryToStoreDataHashSetEffect>(storedValue, usePreviousExit);
    }
}
