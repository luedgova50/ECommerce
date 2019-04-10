namespace ECommerce.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using WebECommerce.Models;

    public class ComBoxHelpers : IDisposable
    {
        private static WebECommerceContext db = new WebECommerceContext();

        public static List<State> GetStates()
        {
            var states = db.State.ToList();

            states.Add(new State
            {
                StateId = 0,
                NameState = "[---Select a State...---]"
            });

           return states =
                    states.
                    OrderBy(
                    d => d.NameState).
                    ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}