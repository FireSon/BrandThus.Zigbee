namespace BrandThus.Zigbee.Zcl;

public enum ZclCommand : ushort
{
    ReadAttributes,
    ReadAttributesResponse,
    WriteAttributes,
    WriteAttributesUndivided,
    WriteAttributesResponse,
    WriteAttributesNoResponse,
    ConfigureReporting,
    ConfigureReportingResponse,
    ReadReportingConfiguration,
    ReadReportingConfigurationResponse,
    ReportAttributes,
    DefaultResponse,
    DiscoverAttributes,
    DiscoverAttributesResponse,
    ReadAttributesStructured,
    WriteAttributesStructured,
    WriteAttributesStructuredResponse,
    DiscoverCommandsReceived,
    DiscoverCommandsReceivedResponse,
    DiscoverCommandsGenerated,
    DiscoverCommandsGeneratedResponse,
    DiscoverAttributesExtended,
    DiscoverAttributesExtendedResponse
}
