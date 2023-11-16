namespace BrandThus.Zigbee.Clusters;

/// <summary>
/// The diagnostics cluster provides access to information regarding the operation of the ZigBee stack over time.
/// <summary>
[Cluster(0x0b05, "Diagnostics")]
public static class ZclDiagnostics
{
    private static readonly ZigbeeCluster zcl = new(typeof(ZclDiagnostics));

    #region Hardware Information
    public static ReportAttribute NumberOfResets { get; } = zcl.Report(0x0000, "Number of Resets", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute PersistensMemoryWrites { get; } = zcl.Report(0x0001, "Persistens Memory Writes", ZigbeeType.U16, r => r.ReadUInt16());
    #endregion 

    #region Stack/Network Information
    public static ReportAttribute MacRxBcast { get; } = zcl.Report(0x0100, "Mac Rx Bcast", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute MacTxBcast { get; } = zcl.Report(0x0101, "Mac Tx Bcast", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute MacRxUcast { get; } = zcl.Report(0x0102, "Mac Rx Ucast", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute MacTxUcast { get; } = zcl.Report(0x0103, "Mac Tx Ucast", ZigbeeType.U32, r => r.ReadUInt32());
    public static ReportAttribute MacTxUcastRetry { get; } = zcl.Report(0x0104, "Mac Tx Ucast Retry", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute MacTxUcastFail { get; } = zcl.Report(0x0105, "Mac Tx Ucast Fail", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute APSRxBcast { get; } = zcl.Report(0x0106, "APS Rx Bcast", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute APSTxBcast { get; } = zcl.Report(0x0107, "APS Tx Bcast", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute APSRxUcast { get; } = zcl.Report(0x0108, "APS Rx Ucast", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute APSTxUcastSuccess { get; } = zcl.Report(0x0109, "APS Tx Ucast Success", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute APSTxUcastRetry { get; } = zcl.Report(0x010a, "APS Tx Ucast Retry", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute APSTxUcastFail { get; } = zcl.Report(0x010b, "APS Tx Ucast Fail", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RouteDiscInitiated { get; } = zcl.Report(0x010c, "Route Disc Initiated", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NeighborAdded { get; } = zcl.Report(0x010d, "Neighbor Added", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NeighborRemoved { get; } = zcl.Report(0x010e, "Neighbor Removed", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NeighborStale { get; } = zcl.Report(0x010f, "Neighbor Stale", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute JoinIndication { get; } = zcl.Report(0x0110, "Join Indication", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute ChildMoved { get; } = zcl.Report(0x0111, "Child Moved", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NWKFCFailure { get; } = zcl.Report(0x0112, "NWK FC Failure", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute APSFCFailure { get; } = zcl.Report(0x0113, "APS FC Failure", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute APSUnauthorizedKey { get; } = zcl.Report(0x0114, "APS Unauthorized Key", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute NWKDecryptFailures { get; } = zcl.Report(0x0115, "NWK Decrypt Failures", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute APSDecryptFailures { get; } = zcl.Report(0x0116, "APS Decrypt Failures", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute PacketBufferAllocFailures { get; } = zcl.Report(0x0117, "Packet Buffer Alloc Failures", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute RelayedUcast { get; } = zcl.Report(0x0118, "Relayed Ucast", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute PhyToMACQueueLimitReached { get; } = zcl.Report(0x0119, "Phy to MAC queue limit reached", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute PacketValidateDropcount { get; } = zcl.Report(0x011a, "Packet Validate Dropcount", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute AvgMACRetryPerAPSMsgSent { get; } = zcl.Report(0x011b, "Avg MAC Retry per APS Msg Sent", ZigbeeType.U16, r => r.ReadUInt16());
    public static ReportAttribute LastMessageLQI { get; } = zcl.Report(0x011c, "Last Message LQI", ZigbeeType.U8, r => r.ReadByte());
    public static ReportAttribute LastMessageRSSI { get; } = zcl.Report(0x011d, "Last Message RSSI", ZigbeeType.S8, r => r.ReadByte());
    #endregion 

    #region Vendor specific attributes
    public static ReportAttribute VendorSWErrorCode { get; } = zcl.Report(0x4000, "SW error code", ZigbeeType.Bmp16, r => r.ReadInt16());
    #endregion 

}
