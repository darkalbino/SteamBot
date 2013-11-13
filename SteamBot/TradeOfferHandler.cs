using SteamKit2;
using System.Collections.Generic;
using SteamTrade;
using SteamTrade.TradeOffer;

namespace SteamBot
{
    public class TradeOfferHandler : UserHandler
    {
        public TradeOfferHandler(Bot bot, SteamID sid) : base(bot, sid) { }

        public override bool OnFriendAdd()
        {
            return true;
        }

        public override void OnLoginCompleted()
        {
        }

        public override void OnChatRoomMessage(SteamID chatID, SteamID sender, string message)
        {
        }

        public override void OnFriendRemove() { }

        public override void OnMessage(string message, EChatEntryType type)
        {
            //New trade
            TradeOffer nTrade = Bot.tradeUser.newTrade(OtherSID);

            var partner_inv = nTrade.SInventory.Initialize(nTrade.partner, 443, 2).getItems();
            var my_inv = nTrade.SInventory.Initialize(Bot.SteamUser.SteamID, 443, 2).getItems();

            //Get trade
            var trades = Bot.tradeUser.getTrades(Bot.SteamUser.SteamID);
            foreach (var trade in trades.tradeIds)
            {
                //Get trade info
            }

            //Get trade by ID
            TradeOffer gTrade = Bot.tradeUser.getTrade(1); // First parameter: trade id

            //Add all trade partner items then send with a message
            foreach (var item in partner_inv)
            {
                nTrade.tradeStatus.them.addItem(443, 2, item.id, item.amount);
            }
            nTrade.update("Updated!");

            //Accept received trade
            gTrade.accept();

            //Decline received trade
            gTrade.decline();
        }

        public override bool OnTradeRequest()
        {
            return false;
        }

        public override void OnTradeError(string error)
        {
        }

        public override void OnTradeTimeout()
        {
        }

        public override void OnTradeInit()
        {
        }

        public override void OnTradeAddItem(Schema.Item schemaItem, Inventory.Item inventoryItem) { }

        public override void OnTradeRemoveItem(Schema.Item schemaItem, Inventory.Item inventoryItem) { }

        public override void OnTradeMessage(string message) { }

        public override void OnTradeReady(bool ready)
        {
        }

        public override void OnTradeAccept()
        {
        }

    }

}

