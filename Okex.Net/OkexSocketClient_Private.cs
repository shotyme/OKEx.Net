using CryptoExchange.Net.Objects.Sockets;

namespace Okex.Net;

public partial class OkexSocketClient
{
    #region Private Signed Feeds
    /// <summary>
    /// Retrieve account information. Data will be pushed when triggered by events such as placing/canceling order, and will also be pushed in regular interval according to subscription granularity.
    /// </summary>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual CallResult<UpdateSubscription> SubscribeToAccountUpdates(
        Action<OkexAccountBalance> onData)
        => SubscribeToAccountUpdatesAsync(onData).Result;
    /// <summary>
    /// Retrieve account information. Data will be pushed when triggered by events such as placing/canceling order, and will also be pushed in regular interval according to subscription granularity.
    /// </summary>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual async Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(
        Action<OkexAccountBalance> onData,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieve position information. Initial snapshot will be pushed according to subscription granularity. Data will be pushed when triggered by events such as placing/canceling order, and will also be pushed in regular interval according to subscription granularity.
    /// </summary>
    /// <param name="instrumentType">Instrument Type</param>
    /// <param name="instrumentId">Instrument ID</param>
    /// <param name="underlying">Underlying</param>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual CallResult<UpdateSubscription> SubscribeToPositionUpdates(
        OkexInstrumentType instrumentType,
        string instrumentId,
        string underlying,
        Action<OkexPosition> onData)
        => SubscribeToPositionUpdatesAsync(instrumentType, instrumentId, underlying, onData).Result;
    /// <summary>
    /// Retrieve position information. Initial snapshot will be pushed according to subscription granularity. Data will be pushed when triggered by events such as placing/canceling order, and will also be pushed in regular interval according to subscription granularity.
    /// </summary>
    /// <param name="instrumentType">Instrument Type</param>
    /// <param name="instrumentId">Instrument ID</param>
    /// <param name="underlying">Underlying</param>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(
        OkexInstrumentType instrumentType,
        string instrumentId,
        string underlying,
        Action<OkexPosition> onData,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieve account balance and position information. Data will be pushed when triggered by events such as filled order, funding transfer.
    /// </summary>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual CallResult<UpdateSubscription> SubscribeToBalanceAndPositionUpdates(
        Action<OkexPositionRisk> onData)
        => SubscribeToBalanceAndPositionUpdatesAsync(onData).Result;
    /// <summary>
    /// Retrieve account balance and position information. Data will be pushed when triggered by events such as filled order, funding transfer.
    /// </summary>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual async Task<CallResult<UpdateSubscription>> SubscribeToBalanceAndPositionUpdatesAsync(
        Action<OkexPositionRisk> onData,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieve order information. Data will not be pushed when first subscribed. Data will only be pushed when triggered by events such as placing/canceling order.
    /// </summary>
    /// <param name="instrumentType">Instrument Type</param>
    /// <param name="instrumentId">Instrument ID</param>
    /// <param name="underlying">Underlying</param>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual CallResult<UpdateSubscription> SubscribeToOrderUpdates(
        OkexInstrumentType instrumentType,
        string instrumentId,
        string underlying,
        Action<OkexOrder> onData)
        => SubscribeToOrderUpdatesAsync(instrumentType, instrumentId, underlying, onData).Result;
    /// <summary>
    /// Retrieve order information. Data will not be pushed when first subscribed. Data will only be pushed when triggered by events such as placing/canceling order.
    /// </summary>
    /// <param name="instrumentType">Instrument Type</param>
    /// <param name="instrumentId">Instrument ID</param>
    /// <param name="underlying">Underlying</param>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(
        OkexInstrumentType instrumentType,
        string instrumentId,
        string underlying,
        Action<OkexOrder> onData,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieve algo orders (includes trigger order, oco order, conditional order). Data will not be pushed when first subscribed. Data will only be pushed when triggered by events such as placing/canceling order.
    /// </summary>
    /// <param name="instrumentType">Instrument Type</param>
    /// <param name="instrumentId">Instrument ID</param>
    /// <param name="underlying">Underlying</param>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual CallResult<UpdateSubscription> SubscribeToAlgoOrderUpdates(
        OkexInstrumentType instrumentType,
        string instrumentId,
        string underlying,
        Action<OkexAlgoOrder> onData)
        => SubscribeToAlgoOrderUpdatesAsync(instrumentType, instrumentId, underlying, onData).Result;
    /// <summary>
    /// Retrieve algo orders (includes trigger order, oco order, conditional order). Data will not be pushed when first subscribed. Data will only be pushed when triggered by events such as placing/canceling order.
    /// </summary>
    /// <param name="instrumentType">Instrument Type</param>
    /// <param name="instrumentId">Instrument ID</param>
    /// <param name="underlying">Underlying</param>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual async Task<CallResult<UpdateSubscription>> SubscribeToAlgoOrderUpdatesAsync(
        OkexInstrumentType instrumentType,
        string instrumentId,
        string underlying,
        Action<OkexAlgoOrder> onData,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieve advance algo orders (includes iceberg order and twap order). Data will be pushed when first subscribed. Data will be pushed when triggered by events such as placing/canceling order.
    /// </summary>
    /// <param name="instrumentType">Instrument Type</param>
    /// <param name="instrumentId">Instrument ID</param>
    /// <param name="underlying">Underlying</param>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual CallResult<UpdateSubscription> SubscribeToAdvanceAlgoOrderUpdates(
        OkexInstrumentType instrumentType,
        string instrumentId,
        string underlying,
        Action<OkexAlgoOrder> onData)
        => SubscribeToAdvanceAlgoOrderUpdatesAsync(instrumentType, instrumentId, underlying, onData).Result;
    /// <summary>
    /// Retrieve advance algo orders (includes iceberg order and twap order). Data will be pushed when first subscribed. Data will be pushed when triggered by events such as placing/canceling order.
    /// </summary>
    /// <param name="instrumentType">Instrument Type</param>
    /// <param name="instrumentId">Instrument ID</param>
    /// <param name="underlying">Underlying</param>
    /// <param name="onData">On Data Handler</param>
    /// <returns></returns>
    public virtual async Task<CallResult<UpdateSubscription>> SubscribeToAdvanceAlgoOrderUpdatesAsync(
        OkexInstrumentType instrumentType,
        string instrumentId,
        string underlying,
        Action<OkexAlgoOrder> onData,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    // TODO: Position risk warning
    // TODO: Account greeks channel
    // TODO: Rfqs channel
    // TODO: Quotes channel
    // TODO: Structure block trades channel
    // TODO: Spot grid algo orders channel
    // TODO: Contract grid algo orders channel
    // TODO: Grid positions channel
    // TODO: Grid sub orders channel

    #endregion
}