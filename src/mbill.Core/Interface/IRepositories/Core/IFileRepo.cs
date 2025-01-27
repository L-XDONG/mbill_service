﻿using mbill.Core.Domains.Entities.Core;
using mbill.Core.Interface.IRepositories.Base;

namespace mbill.Core.Interface.IRepositories.Core
{
    public interface IFileRepo : IAuditBaseRepo<FileEntity>
    {
        /// <summary>
        /// 获取文件完整路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string GetFileUrl(string path);
    }
}
