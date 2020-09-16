using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP.Models;

namespace TP1_Module05.DAO
{
    public class FakeDb
    {
        private static readonly Lazy<FakeDb> lazy =
            new Lazy<FakeDb>(() => new FakeDb());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDb Instance { get { return lazy.Value; } }

        public List<Chat> Chats { get; set; }

        private FakeDb()
        {
            this.Chats = Chat.GetMeuteDeChats();
        }
    }
}