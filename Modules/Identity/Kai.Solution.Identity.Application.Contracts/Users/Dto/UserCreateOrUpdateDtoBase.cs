using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Kai.Solution.Identity;

public abstract class UserCreateOrUpdateDtoBase : ExtensibleObject
{
    [Required]
    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxUserNameLength))]
    public string UserName { get; set; }

    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxNameLength))]
    public string Name { get; set; }

    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxSurnameLength))]
    public string Surname { get; set; }

    [Required]
    [EmailAddress]
    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxEmailLength))]
    public string Email { get; set; }

    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxPhoneNumberLength))]
    public string PhoneNumber { get; set; }

    public bool IsActive { get; set; }

    public bool LockoutEnabled { get; set; }

    [CanBeNull]
    public string[] RoleNames { get; set; }

    protected UserCreateOrUpdateDtoBase() : base(false)
    {

    }
}
