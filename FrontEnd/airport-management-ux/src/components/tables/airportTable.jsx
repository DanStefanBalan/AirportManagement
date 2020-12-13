import React, { Component } from "react";
import TableHeader from "./../common/table/tableHeader";
import TableBody from "../common/table/tableBody";
import { Link } from "react-router-dom";

class AirportTable extends Component {
  columns = [
    {
      path: "name",
      label: "Name",
      content: (airport) => (
        <Link to={`/admin/add-airport/${airport.id}`}>{airport.name}</Link>
      ),
    },
    {
      path: "country",
      label: "Country",
    },
    {
      path: "city",
      label: "City",
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
    const { airports, onSort, sortColumn } = this.props;
    return (
      <div>
        <table className={"tables"}>
          <TableHeader
            columns={this.columns}
            sortColumn={sortColumn}
            onSort={onSort}
          />
          <TableBody data={airports} columns={this.columns} />
        </table>
      </div>
    );
  }
}
export default AirportTable;
