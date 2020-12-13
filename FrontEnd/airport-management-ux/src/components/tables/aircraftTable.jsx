import React, { Component } from "react";
import TableHeader from "../common/table/tableHeader";
import TableBody from "../common/table/tableBody";
import { Link } from "react-router-dom";

class AircraftTable extends Component {
  columns = [
    {
      path: "flightId",
      label: "Flight Id"
    },
    {
      path: "aircraftNumber",
      label: "Aircraft Number",
      content: aircraft => (
        <Link to={`/admin/add-aircraft/${aircraft.id}`}>
          {aircraft.aircraftNumber}
        </Link>
      )
    },
    {
      path: "countryOfRegistration",
      label: "Country Of Registration"
    },
    {
      path: "numberOfPilots",
      label: "Number Of Pilots"
    },
    {
      path: "manufacturer",
      label: "Manufacturer"
    },
    {
      path: "model",
      label: "Model"
    },
    {
      path: "numberOfSeats",
      label: "Number Of Seats"
    },
    {
      path: "numberOfFlightAttendants",
      label: "Number Of FlightAttendants"
    },
    {
      path: "delete",
      content: aircraft => (
        <button
          onClick={() => this.props.onDelete(aircraft)}
          className="btn btn-danger btn-sm"
        >
          Delete
        </button>
      )
    }
  ];
  render() {
    const { aircrafts, onSort, sortColumn } = this.props;
    return (
      <div>
        <table className={"tables"}>
          <TableHeader
            columns={this.columns}
            sortColumn={sortColumn}
            onSort={onSort}
          />
          <TableBody data={aircrafts} columns={this.columns} />
        </table>
      </div>
    );
  }
}
export default AircraftTable;
