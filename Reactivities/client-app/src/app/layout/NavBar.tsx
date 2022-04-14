import React from "react";
import { Button, Nav, Navbar } from "react-bootstrap";

export default function NavBar() {
  return (
    <>
      <Navbar sticky="top" variant="dark" className="top-navbar">
        <Navbar.Brand href="/">
          <img src="./assets/logo.png" alt="logo" className="logo"></img>{" "}
          Reactivities
        </Navbar.Brand>
        <Nav>
          <Nav.Link href="#">Activities</Nav.Link>
          <Button>Create Activity</Button>
        </Nav>
      </Navbar>
    </>
  );
}
