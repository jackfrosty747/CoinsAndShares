Imports CoinsAndShares.Instruments.MInstuments

Namespace Rates
    Module MRates

        Friend Enum ERateProvider
            Alphavantage = 1
            CNBC = 2
            CoinGecko = 3
            FMP = 4
            GoogleFinance = 5
            MarketWatch = 6
            MorningStar = 7
            YahooFinance = 8
        End Enum

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

        Friend Function GetRateProvider(commonObjects As CCommonObjects, rateProvider As ERateProvider) As IRateProvider

            Select Case rateProvider
                Case ERateProvider.Alphavantage
                    Return New Alphavantage.CAlphavantage(commonObjects)
                Case ERateProvider.CNBC
                    Return New CNBC.CCnbc()
                Case ERateProvider.CoinGecko
                    Return New CoinGecko.CCoinGecko()
                Case ERateProvider.FMP
                    Return New FMP.CFMP()
                Case ERateProvider.GoogleFinance
                    Return New GoogleFinance.CGoogleFinance()
                Case ERateProvider.MarketWatch
                    Return New MarketWatch.CMarketWatch()
                Case ERateProvider.MorningStar
                    Return New MorningStar.CMorningStar()
                Case ERateProvider.YahooFinance
                    Return New YahooFinance.CYahooFinance()
                Case Else
                    Throw New ArgumentOutOfRangeException(NameOf(rateProvider))
            End Select

        End Function

    End Module

End Namespace
