using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Ninja;
using api.Models;

namespace api.Services.NinjaServices
{
    public interface INinjaService
    {
        public Task<ServiceResponse<List<NinjaGetDto>>> GetAll();
        public Task<ServiceResponse<NinjaGetDto>> GetById(int id);
        public Task<ServiceResponse<List<NinjaGetDto>>> AddNinja(NinjaPostDto newNinja);
        public Task<ServiceResponse<NinjaGetDto>> UpdateNinja(NinjaUpdateDto updatedNinja);
        public Task<ServiceResponse<List<NinjaGetDto>>> DeleteNinja(int id);
    }
}