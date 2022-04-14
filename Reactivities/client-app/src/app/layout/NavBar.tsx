import { Button, Nav, Navbar } from "react-bootstrap";

interface Props {
  openForm: () => void;
}

export default function NavBar({ openForm }: Props) {
  return (
    <>
      <Navbar sticky="top" variant="dark" className="top-navbar">
        <Navbar.Brand href="/">
          <img src="./assets/logo.png" alt="logo" className="logo"></img>{" "}
          Reactivities
        </Navbar.Brand>
        <Nav>
          <Nav.Item>
            <Nav.Link href="#">Activities</Nav.Link>
          </Nav.Item>
          <Nav.Item>
            <Button onClick={openForm}>Create Activity</Button>
          </Nav.Item>
        </Nav>
      </Navbar>
    </>
  );
}
