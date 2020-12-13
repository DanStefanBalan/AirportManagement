import React, { Component } from "react";
import TableHeader from "./../common/table/tableHeader";
import TableBody from "../common/table/tableBody";
import { Link } from "react-router-dom";

class DestinationTable extends Component {
  columns = [
    {
      path: "localtime",
      label: "Local Time",
    },
    {
      path: "weather",
      label: "Weather",
    },
    {
      path: "airportid",
      label: "Airport Id",
    },
    {
      path: "flightid",
      label: "Flight Id",
    },
    {
      path: "delete",
      content: (airport) => (
        <button
          onClick={() => this.props.onDelete(airport)}
          className="btn btn-danger btn-md"
        >
          Delete
        </button>
      ),
    },
  ];
  render() {
    const { destiantions, onSort, sortColumn } = this.props;
    return (
      <div>
        <table className="tables">
          <TableHeader
            columns={this.columns}
            sortColumn={sortColumn}
            onSort={onSort}
          />
          <TableBody data={destiantions} columns={this.columns} />
        </table>
      </div>
    );
  }
}
export default DestinationTable;
