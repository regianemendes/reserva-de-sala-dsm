﻿using Microsoft.EntityFrameworkCore;
using reserva_de_sala_dsm.Data;
using reserva_de_sala_dsm.Interfaces;
using reserva_de_sala_dsm.Models;
using System.Collections;

namespace reserva_de_sala_dsm.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _context;
        public UsuarioRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(u => email == email);
        }
        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }
        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }
        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetByIdAsync(long id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
    }
}
