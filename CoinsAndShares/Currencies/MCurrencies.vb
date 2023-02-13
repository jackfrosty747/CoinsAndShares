Imports CoinsAndShares.Settings

Namespace Currencies
    Module MCurrencies
        Friend Function GetCurrencyRateApiToUse(commonObjects As CCommonObjects) As ICurrencyRateApi
            Dim settings As New CSettings(commonObjects)
            Return New ExchangeRatesApiIo.CExchangeRatesApiIo(settings.ExchangeRatesApiKey)
        End Function
    End Module

End Namespace

