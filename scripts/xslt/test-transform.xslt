<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>

	<!--copy all-->
	<xsl:template match="@*|node()">
	<xsl:copy>
	  <xsl:apply-templates select="@*|node()"/>
	</xsl:copy>
	</xsl:template>
	

	<!--make value attribute to code element-->
    <xsl:template match="@value">
        <xsl:element name="Code">
            <xsl:value-of select="."/>
        </xsl:element>
    </xsl:template>

    <!-- move up doc node one level. chain apply-templates! -->
    <xsl:template match="annotation">
    <xsl:variable name="t2">
        <xsl:copy>
            <xsl:apply-templates select="child::node()[not(self::documentation)]"/>
        </xsl:copy>
    </xsl:variable>
    <xsl:apply-templates select="documentation" />
    </xsl:template>
    
    <!--rename doc to Name-->
    <xsl:template match="documentation">
		<xsl:variable name="t3">
			<Name>
				<xsl:value-of select="."/>
			</Name>    
		</xsl:variable>
		<xsl:apply-templates select="$t3"/>    
    </xsl:template>
	
</xsl:stylesheet>				


