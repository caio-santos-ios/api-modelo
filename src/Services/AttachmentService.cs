using api_infor_cell.src.Handlers;
using api_infor_cell.src.Interfaces;
using api_infor_cell.src.Models;
using api_infor_cell.src.Models.Base;
using api_infor_cell.src.Shared.DTOs;
using api_infor_cell.src.Shared.Utils;
using AutoMapper;

namespace api_infor_cell.src.Services
{
    public class AttachmentService(IAttachmentRepository attachmentRepository, IMapper _mapper, UploadHandler uploadHander) : IAttachmentService
    {
        #region READ
        public async Task<ResponseApi<PaginationApi<List<dynamic>>>> GetAllAsync(GetAllDTO request)
        {
            try
            {
                PaginationUtil<Attachment> pagination = new(request.QueryParams);
                ResponseApi<List<dynamic>> attachments = await attachmentRepository.GetAllAsync(pagination);
                int count = await attachmentRepository.GetCountDocumentsAsync(pagination);
                PaginationApi<List<dynamic>> data = new(attachments.Data, count, pagination.PageNumber, pagination.PageSize); 
                return new(data, 200, "Contas a receber listados com sucesso");
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        
        public async Task<ResponseApi<dynamic?>> GetByIdAggregateAsync(string id)
        {
            try
            {
                ResponseApi<dynamic?> attachment = await attachmentRepository.GetByIdAggregateAsync(id);
                if(attachment.Data is null) return new(null, 404, "Anexo não encontrado");
                return new(attachment.Data);
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        #endregion
        
        #region CREATE
        public async Task<ResponseApi<Attachment?>> CreateAsync(CreateAttachmentDTO request)
        {
            try
            {
                if(request.File is null) return new(null, 400, "Arquivo é obrigatório.");

                Attachment attachment = _mapper.Map<Attachment>(request);

                string uriPhoto = await uploadHander.UploadAttachment(request.Parent, request.File, $"/api/{request.Parent}");

                if(string.IsNullOrEmpty(uriPhoto)) return new(null, 400, "Falha ao criar Anexo.");

                ResponseApi<Attachment?> response = await attachmentRepository.CreateAsync(attachment);

                await attachmentRepository.UpdateAsync(attachment);

                if(response.Data is null) return new(null, 400, "Falha ao criar Anexo.");
                return new(response.Data, 201, "Anexo criado com sucesso.");
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        #endregion
        
        #region UPDATE
        public async Task<ResponseApi<Attachment?>> UpdateAsync(UpdateAttachmentDTO request)
        {
            try
            {
                ResponseApi<Attachment?> attachmentResponse = await attachmentRepository.GetByIdAsync(request.Id);
                if(attachmentResponse.Data is null) return new(null, 404, "Falha ao atualizar");
                
                Attachment attachment = _mapper.Map<Attachment>(request);
                attachment.UpdatedAt = DateTime.UtcNow;

                ResponseApi<Attachment?> response = await attachmentRepository.UpdateAsync(attachment);
                if(!response.IsSuccess) return new(null, 400, "Falha ao atualizar");

                return new(response.Data, 200, "Atualizado com sucesso");
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        #endregion
        
        #region DELETE
        public async Task<ResponseApi<Attachment>> DeleteAsync(string id)
        {
            try
            {
                ResponseApi<Attachment> attachment = await attachmentRepository.DeleteAsync(id);
                if(!attachment.IsSuccess) return new(null, 400, attachment.Message);
                return new(null, 204, "Excluído com sucesso");
            }
            catch(Exception ex)
            {
                return new(null, 500, $"Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. {ex.Message}");
            }
        }
        #endregion 
    }
}