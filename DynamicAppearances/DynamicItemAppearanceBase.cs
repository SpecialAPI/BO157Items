using System;
using System.Collections.Generic;
using System.Text;

namespace BO157Items.DynamicAppearances
{
    public abstract class DynamicItemAppearanceBase
    {
        public virtual void ModifyItemDescription(ref string description)
        {
        }
    }
}
