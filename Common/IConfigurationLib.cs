
namespace Common
{
    /// <summary>
    /// Generic Keys of WebConfig for Application
    /// </summary>
    public interface IConfigurationLib
    {
        int CodigoExito { get; }
        string MensajeExitoES { get; }
        string MensajeExitoEN { get; }

        int CodigoErrorNoDataFound { get; }
        string NoDataFoundES { get; }
        string NoDataFoundEN { get; }


        int CodigoLogin { get; }
        string MensajeLoginES { get; }


        /*int CodigoExisteUsuario { get; }
        string MensajeExisteUsuarioES { get; }
        string MensajeExisteUsuarioEN { get; }*/

        int CodigoUserExist { get; }
        string MensajeUserExistEN { get; }
        string MensajeUserExistES { get; }


        int CodigoPasswordNoCoincide { get; }
        string MensajePasswordNoCoincideES { get; }
        string MensajePasswordNoCoincideEN { get; }


        int CodigoParametrosNoValido { get; }
        string MensajeParametrosNoValidoEN { get; }
        string MensajeParametrosNoValidoES { get; }

        int CodigoGastoRepetido { get; }
        string MensajeGastoRepetidoEN { get; }
        string MensajeGastoRepetidoES { get; }

        int CodigoErrorBD { get; }
        string MensajeErrorBDEN { get; }
        string MensajeErrorBDES { get; }


        int CodigoErrorTimeOut { get; }
        string MensajeErrorTimeOutEN { get; }
        string MensajeErrorTimeOutES { get; }

        int CodigoErrorNoEspecificado { get; }
        string MensajeErrorNoEspecificadoEN { get; }
        string MensajeErrorNoEspecificadoES { get; }

        int CodigoErrorNoFound { get; }
        string MensajeErrorNoFoundEN { get; }
        string MensajeErrorNoFoundES { get; }

        int CodigoErrorNoAuthorized { get; }
        string MensajeErrorNoAuthorizedEN { get; }
        string MensajeErrorNoAuthorizedES { get; }

        int SecondsTimeOutBD { get; }
        string LDAP { get; }
        string Domain { get; }
        string userNameWicService { get; }
        string passwordWicService { get; }
        string urlBase { get; }
        string urlServer { get; }
        string Prefix { get; }
        string TokenType { get; }
        string TokenController { get; }
        string StatusController { get; }
        string DetailsController { get; }

        int CodigoDataExists { get; }
        string MensajeDataExistsEN { get; }
        string MensajeDataExistsES { get; }

        int CodigoMissingParameters { get; }
        string MensajeMissingParametersEN { get; }
        string MensajeMissingParametersES { get; }


        string MessageUserRegisterES { get; }
        string MessageUserRegisterEN { get; }
        string MessageUserBlockedES { get; }
        string MessageUserBlockedEN { get; }

        int CodigoBadCredentials { get; }
        string MensajeBadCredentialsEN { get; }
        string MensajeBadCredentialsES { get; }

        int CodigoAccountSuspended { get; }
        string MensajeAccountSuspendedEN { get; }
        string MensajeAccountSuspendedES { get; }

        string FilePath { get; }

        string WordPathES { get; }
        string WordPathEN { get; }

        int CodigoUserNoExist { get; }
        string MensajeUserNoExistEN { get; }
        string MensajeUserNoExistES { get; }


        int CodigoRoleRegionObligatory { get; }
        string MensajeRoleRegionObligatoryEN { get; }
        string MensajeRoleRegionObligatoryES { get; }

        int CodigoExistsComment { get; }
        string MensajeExistsCommentEN { get; }
        string MensajeExistsCommentES { get; }

        int CodigoErrorInsertComment { get; }
        string MensajeErrorInsertCommentEN { get; }
        string MensajeErrorInsertCommentES { get; }
    }
}
