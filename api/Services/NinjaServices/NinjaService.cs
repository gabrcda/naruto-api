using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Ninja;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services.NinjaServices
{
    public class NinjaService : INinjaService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public NinjaService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<NinjaGetDto>>> GetAll()
        {
            var response = new ServiceResponse<List<NinjaGetDto>>();
            var allNinjas = await _context.Ninjas.ToListAsync();
            response.Data = allNinjas.Select(c => _mapper.Map<NinjaGetDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<NinjaGetDto>> GetById(int id)
        {
            var response = new ServiceResponse<NinjaGetDto>();
            try
            {
                var searchedNinja = await _context.Ninjas.FindAsync(id);
                if(searchedNinja is null)
                {
                    throw new Exception($"Ninja with id {id} not found");
                }
                response.Data = _mapper.Map<NinjaGetDto>(searchedNinja);
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<NinjaGetDto>>> AddNinja(NinjaPostDto newNinja)
        {
            var response = new ServiceResponse<List<NinjaGetDto>>();
            try
            {
                var addNinja = _mapper.Map<NinjaModel>(newNinja);
                await _context.Ninjas.AddAsync(addNinja);
                await _context.SaveChangesAsync();
                var allNinjas = await _context.Ninjas.ToListAsync();
                response.Data = allNinjas.Select(c => _mapper.Map<NinjaGetDto>(c)).ToList();
            }
            catch(Exception ex)
            {
                response.IsSucess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<NinjaGetDto>> UpdateNinja(NinjaUpdateDto updatedNinja)
        {
            var response = new ServiceResponse<NinjaGetDto>();
            try
            {
                var searchedNinja = await _context.Ninjas.FindAsync(updatedNinja.Id);
                if(searchedNinja is null)
                {
                    throw new Exception($"Ninja with id {updatedNinja.Id} not found");
                }
                else
                {
                    searchedNinja.Name = updatedNinja.Name;
                    searchedNinja.Age = updatedNinja.Age;
                    searchedNinja.Clan = updatedNinja.Clan;
                    searchedNinja.Village = updatedNinja.Village;
                    searchedNinja.Ranking = updatedNinja.Ranking;
                    await _context.SaveChangesAsync();
                    response.Data = _mapper.Map<NinjaGetDto>(searchedNinja);
                }
            }
            catch(Exception ex)
            {
                response.IsSucess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<NinjaGetDto>>> DeleteNinja(int id)
        {
            var response = new ServiceResponse<List<NinjaGetDto>>();
            try
            {
                var removedNinja = await _context.Ninjas.FindAsync(id);
                if(removedNinja is null)
                {
                    throw new Exception($"Ninja with id {id} not found");
                }
                else
                {
                    _context.Ninjas.Remove(removedNinja);
                    await _context.SaveChangesAsync();
                    var allNinjas = await _context.Ninjas.ToListAsync();
                    response.Data = allNinjas.Select(c => _mapper.Map<NinjaGetDto>(c)).ToList();
                }
            }
            catch(Exception ex)
            {
                response.IsSucess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}