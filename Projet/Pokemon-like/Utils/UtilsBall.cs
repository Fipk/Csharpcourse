using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pokemon_like.Program;

namespace Pokemon_like
{
    interface IBall
    {
        bool Catch(Pokemon pokemon, ref Player player);
    }
}
