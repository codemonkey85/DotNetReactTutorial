import { Button, Card } from "react-bootstrap";
import { Activity } from "../../../app/models/activity";

interface Props {
  activity: Activity;
  cancelSelectActivity: () => void;
  openForm: (id: string) => void;
}

export default function ActivityDetails({
  activity,
  cancelSelectActivity,
  openForm,
}: Props) {
  return (
    <Card>
      {activity.category && (
        <Card.Img
          variant="top"
          src={`./assets/categoryImages/${activity.category}.jpg`}
        />
      )}
      <Card.Header>
        <h3>{activity.title}</h3>
      </Card.Header>
      <Card.Body>
        <Card.Text>{activity.description}</Card.Text>
        <Button onClick={() => openForm(activity.id)} variant="primary">
          Edit
        </Button>
        <Button onClick={cancelSelectActivity} variant="secondary">
          Cancel
        </Button>
      </Card.Body>
    </Card>
  );
}
