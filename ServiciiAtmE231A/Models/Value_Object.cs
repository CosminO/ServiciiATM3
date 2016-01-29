﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciiAtmE231A.Models
{
    public class Value_Object
    {
        private int _idUser;
        private string _firstname;
        private string _lastname;
        private string _email;

        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public Value_Object()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int idUser
        {
            get
            {
                return _idUser;
            }

            set
            {
                _idUser = value;
            }
        }

        public string firstname
        {
            get
            {
                return _firstname;
            }

            set
            {
                _firstname = value;
            }
        }

        public string lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }

        public string email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }
    }
}