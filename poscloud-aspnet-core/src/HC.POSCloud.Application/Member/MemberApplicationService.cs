
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using HC.POSCloud.Members;
using HC.POSCloud.Members.Dtos;
using HC.POSCloud.Members.DomainService;
using HC.POSCloud.Members.Authorization;


namespace HC.POSCloud.Members
{
    /// <summary>
    /// Member应用层服务的接口实现方法  
    ///</summary>
    //[AbpAuthorize]
    public class MemberAppService : POSCloudAppServiceBase, IMemberAppService
    {
        private readonly IRepository<Member, Guid> _entityRepository;

        private readonly IMemberManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public MemberAppService(
        IRepository<Member, Guid> entityRepository
        , IMemberManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取Member的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<MemberListDto>> GetPagedMemberListAsync(GetMembersInput input)
        {
            var query = _entityRepository.GetAll()
               .WhereIf(!string.IsNullOrEmpty(input.Filter), r => r.NickName.Contains(input.Filter) || r.Phone.Contains(input.Filter));
            var count = await query.CountAsync();
            var entityList = await query
                    .OrderByDescending(v => v.CreationTime).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();
            var entityListDtos = entityList.MapTo<List<MemberListDto>>();
            return new PagedResultDto<MemberListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取MemberListDto信息
        /// </summary>
        public async Task<MemberListDto> GetMemberByIdAsync(Guid id)
        {
            var entity = await _entityRepository.GetAsync(id);
            return entity.MapTo<MemberListDto>();
        }

        /// <summary>
        /// 获取编辑 Member
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(MemberPermissions.Create, MemberPermissions.Edit)]
        public async Task<GetMemberForEditOutput> GetForEdit(NullableIdDto<Guid> input)
        {
            var output = new GetMemberForEditOutput();
            MemberEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<MemberEditDto>();

                //memberEditDto = ObjectMapper.Map<List<memberEditDto>>(entity);
            }
            else
            {
                editDto = new MemberEditDto();
            }

            output.Member = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改Member的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<MemberEditDto> CreateOrUpdateMemberAsync(MemberEditDto input)
        {

            if (input.Id.HasValue)
            {
                return await Update(input);
            }
            else
            {
                return await Create(input);
            }
        }


        /// <summary>
        /// 新增Member
        /// </summary>
        protected virtual async Task<MemberEditDto> Create(MemberEditDto input)
        {
            var entity = input.MapTo<Member>();
            var id = await _entityRepository.InsertAndGetIdAsync(entity);
            return entity.MapTo<MemberEditDto>();
        }

        /// <summary>
        /// 编辑Member
        /// </summary>
        protected virtual async Task<MemberEditDto> Update(MemberEditDto input)
        {
            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);
            await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<MemberEditDto>();
        }



        /// <summary>
        /// 删除Member信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(MemberPermissions.Delete)]
        public async Task Delete(EntityDto<Guid> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除Member的方法
        /// </summary>
        [AbpAuthorize(MemberPermissions.BatchDelete)]
        public async Task BatchDelete(List<Guid> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }


        /// <summary>
        /// 检查是否存在会员
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<bool> GetIsExistByPhoneAsync(string phone)
        {
            int count = await _entityRepository.GetAll().Where(v => v.Phone == phone).CountAsync();
            if (count == 0)
            {
                return false;
            }
            return true;
        }
    }
}


