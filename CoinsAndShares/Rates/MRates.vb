Imports CoinsAndShares.Instruments.MInstuments

Namespace Rates
    Module MRates
        Friend Function GetRateProviderToUse(instrumentType As EInstrumentType) As IRateProvider
            ' commonObjects may be needed in case we want to get the provider from settings
            If instrumentType = EInstrumentType.Crypto Then
                Return New CoinGecko.CCoinGecko
            Else
                'Return New MarketWatch.CMarketWatch
                'Return New YahooFinance.CYahooFinance
                'Return New MorningStar.CMorningStar
                'Return New CNBC.CCnbc
                'Return New GoogleFinance.CGoogleFinance
                Return New FMP.CFMP
            End If
        End Function
    End Module

End Namespace
