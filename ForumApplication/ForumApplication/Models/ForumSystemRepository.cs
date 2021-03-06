﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ForumApplication.Models
{
    public class ForumSystemRepository :IQueries
    {
        public ForumSystemRepository()
        {
            //var context = new ForumDBContext();
            string username = "dean";
            var context = new ForumDBContext();
            var query = from mem in context.Members where mem.Username == username select mem;
            var member = query.FirstOrDefault();
        }

        public ForumSystemRepository(string connectionString)
        {
            var db = new ForumDBContext();
            string username = "dean";
            // Uses it just before any other execution.
            db.ChangeDatabaseTo(connectionString);
            var query = from mem in db.Members where mem.Username == username select mem;
            var member = query.FirstOrDefault();
        }
        
        /*public void dbRetrieveLastID()
        {
            if
            var context = new ForumDBContext();
            
        }*/


        //Forums
        //public List<Forum> getForums()
        //{
        //    ForumDBContext fdbc = new ForumDBContext();
        //    return fdbc.Forums.ToList();
        //}

        //Messages
        //public List<Message> dbGetMessages()
        //{
        //var context = new ForumDBContext();
        //var query = from message in context.Messages select message;
        //var messages = query.ToList();
        //return members;
        //}

        public void dbAddMessage(Message message)
        {
            var context = new ForumDBContext();
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public void dbRemoveMessage(string messageID)
        {
            var context = new ForumDBContext();
            var message = (from m in context.Messages
                           where m.ID == messageID
                           select m).FirstOrDefault();
            context.Messages.Remove(message);
            context.SaveChanges();
        }

        //Members
        //public List<Member> dbGetMembers()
        //{
        //    var context = new ForumDBContext();
        //    var query = from member in context.Members select member;
        //    var members = query.ToList();
        //    return members;
        //}

        public bool dbIsMemberExists(string username)
        {
            var context = new ForumDBContext();
            var query = from mem in context.Members where mem.Username == username select mem;
            var member = query.FirstOrDefault();
            return (member != null);
        }

        public void dbAddMember(Member member)
        {
            var context = new ForumDBContext();
            context.Members.Add(member);
            context.SaveChanges();
        }

        public void dbRemoveMember(string username)
        {
            var context = new ForumDBContext();
            var member = (from m in context.Members
                          where m.Username == username
                          select m).FirstOrDefault();
            context.Members.Remove(member);
            context.SaveChanges();
        }
    }
}