﻿namespace mbill.Core.Domains.Entities.Core;

/// <summary>
/// 图片媒体文件信息表
/// </summary>
[Table(Name = SystemConst.DbTablePrefix + "_media_image")]
[Index("index_media_image_on_file_id", "FileId", false)]
[Index("index_media_image_on_type", "Type", false)]
public class MediaImageEntity : FullAduitEntity
{
    /// <summary>
    /// 文件Id
    /// </summary>
    public long FileId { get; set; }

    /// <summary>
    /// 图片类型：0 Icon, 1 background
    /// </summary>
    public int Type { get; set; }


    [Navigate("FileId")]
    public virtual FileEntity File { get; set; }
}
