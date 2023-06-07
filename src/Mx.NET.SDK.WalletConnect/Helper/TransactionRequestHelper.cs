﻿using System.Linq;
using Mx.NET.SDK.Domain;
using Mx.NET.SDK.WalletConnect.Data;
using Mx.NET.SDK.WalletConnect.Models;

namespace Mx.NET.SDK.WalletConnect.Helper
{
    public static class TransactionRequestHelper
    {
        public static RequestData GetSignTransactionRequest(this TransactionRequest transaction)
        {
            return new RequestData()
            {
                chainID = transaction.ChainId,
                data = transaction.Data is null ? "" : transaction.Data,
                gasLimit = transaction.GasLimit.Value,
                gasPrice = transaction.GasPrice,
                nonce = transaction.Nonce,
                sender = transaction.Sender.Bech32,
                receiver = transaction.Receiver.Bech32,
                value = transaction.Value.ToString(),
                version = transaction.Version,
            };
        }

        public static RequestData[] GetSignTransactionsRequest(this TransactionRequest[] transactions)
        {
            return transactions.Select(transaction => new RequestData()
            {
                chainID = transaction.ChainId,
                data = transaction.Data is null ? "" : transaction.Data,
                gasLimit = transaction.GasLimit.Value,
                gasPrice = transaction.GasPrice,
                nonce = transaction.Nonce,
                sender = transaction.Sender.Bech32,
                receiver = transaction.Receiver.Bech32,
                value = transaction.Value.ToString(),
                version = transaction.Version
            }).ToArray();
        }
    }
}
