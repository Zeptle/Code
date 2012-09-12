﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false"
    CodeFile="Deduplication.aspx.vb" Inherits="Deduplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Deduplication</h2>
    <p>
        The move from HighTouch to SIMS is a move from a distributed system to a centralized
        system. In HighTouch, which is a distributed system, Customer creation is done at
        the store level. Each store assigns a customer number that is unique for that store,
        but is not unique across all stores, therefore it is possible for different customers
        to have the same HighTouch Customer number. In order to mitigate this issue, a unique
        customer number, referred to as the HO Customer Number, is created, consisting of
        a Home Office prefix, a Company Code, a three-character store identifier (‘Bingo
        Code’) and the internal HT Customer Number when a new customer is added. The only
        way multiple Customer records with the same HO Customer Number can exist is if a
        Customer is transferred to another store. When that happens a new Customer record
        is created with the new store number, new Internal HighTouch Customer, but with
        the HO Customer Number from the source store. A Customer transfer generated by the
        store and, again, is the only way the same HO Customer Number can exist for customers
        in two different stores.
    </p>
    <p>
        MDM will provide Customer Deduplication functionality to eliminate as many duplicates
        as possible, while at the same time minimizing the risk of combining customers that
        are not duplicates. The deduplication process is driven by different customer attributes
        through a sequence of checks to determine if there is a match.</p>
    <p>
        The high-level functional definition of the rules is as follows:</p>
    <ol>
        <li>If the HO_CUSTOMER_NUMBER and NAME both match, the Customer record is considered
            a duplicate and the information is used to update the existing Customer.</li>
        <li>If the HO_CUSTOMER_NUMBER does not match, but the NAME matches, Level 2 values are
            checked.</li>
        <ol type="a">
            <li>If, in addition to the NAME match, the TAX_ID, BIRTH_DATE and DL_NUMBER match, the
                Customer record is considered a duplicate and the information is used to update
                the existing Customer</li>
            <li>If the TAX_ID, BIRTH_DATE and DL_NUMBER all do not match or one or more values are
                not present, the Customer is considered a new Customer.</li>
        </ol>
        <li>If the HO_CUSTOMER_NUMBER matches but the NAME does not, the Customer is considered
            a new Customer.</li>
        <li>If the HO_CUSTOMER_NUMBER and the NAME do not match, the Customer is considered
            a new Customer.</li>
    </ol>
    <i><b>Note:</b> Corporate Leasing Customers will not be deduplicated.</i>
    <p>
        The following model illustrates the deduplication levels for an RTO customer:</p>
    <table border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <b>Level</b>
            </td>
            <td>
                <b>Field 1</b>
            </td>
            <td>
                <b>Field 2</b>
            </td>
            <td>
                <b>Field 3</b>
            </td>
            <td>
                <b>Field 4</b>
            </td>
            <td>
                <b>Field 5</b>
            </td>
        </tr>
        <tr>
            <td>
                1
            </td>
            <td>
                HO_CUSTOMER_NUMBER
            </td>
            <td>
                NAME
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                2
            </td>
            <td>
            </td>
            <td>
                NAME
            </td>
            <td>
                TAX_ID
            </td>
            <td>
                BIRTH_DATE
            </td>
            <td>
                DL_NUMBER
            </td>
        </tr>
    </table>
    <p>
        The data in this matrix was selected for the following reasons:</p>
    <p>
        <b>Level One</b> – The HO_CUSTOMER_NUMBER was selected because it is unique by customer.
        If a customer transfers to another store, the HO_CUSTOMER_NUMBER is also transferred.
        The name is included because it is considered unique when the individual Customers
        are extracted from the Customer record, since the HO_CUSTOMER_NUMBER, HT_CUSTOMER_NUMBER,
        STORE_NUMBER, ADDRESS_LINE_1, CITY, STATE and ZIP will be the same for all extracted
        Customer records.
    </p>
    <p>
        <b>Level Two</b> – The TAX_ID, BIRTH_DATE AND DL_NUMBER are unique by person and
        do not normally change, except when a Customer moves to another state. If the Level
        2 information plus the NAME from Level 1 match exactly, the record is considered
        to be a duplicate and the Customer record will be updated.
    </p>
</asp:Content>