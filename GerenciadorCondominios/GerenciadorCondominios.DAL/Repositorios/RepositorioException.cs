﻿namespace GerenciadorCondominios.DAL.Repositorios
{
    public class RepositorioException : Exception
    {
        public RepositorioException() { }
        public RepositorioException(string message) : base(message) { }
        public RepositorioException(string message, Exception inner) : base(message, inner) { }
    }

}
