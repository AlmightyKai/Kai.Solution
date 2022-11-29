using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Volo.Abp.ExceptionHandling;
using Kai.Solution.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp;

namespace Kai.Solution.Identity;

[Serializable]
public class AbpIdentityResultException : BusinessException, ILocalizeErrorMessage
{
    public IdentityResult IdentityResult { get; }

    public AbpIdentityResultException([NotNull] IdentityResult identityResult)
        : base(
            code: $"Kai.Solution.Identity:{identityResult.Errors.First().Code}",
            message: identityResult.Errors.Select(err => err.Description).JoinAsString(", "))
    {
        IdentityResult = Check.NotNull(identityResult, nameof(identityResult));
    }

    public AbpIdentityResultException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
    {

    }

    public virtual string LocalizeMessage(LocalizationContext context)
    {
        var localizer = context.LocalizerFactory.Create<Resource>();

        SetData(localizer);

        return IdentityResult.LocalizeErrors(localizer);
    }

    protected virtual void SetData(IStringLocalizer localizer)
    {
        var values = IdentityResult.GetValuesFromErrorMessage(localizer);

        for (var index = 0; index < values.Length; index++)
        {
            Data[index.ToString()] = values[index];
        }
    }
}
