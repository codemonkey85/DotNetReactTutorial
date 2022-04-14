import { Button, ListGroup } from "react-bootstrap";
import { Activity } from "../../../app/models/activity";

interface Props {
  activities: Activity[];
  selectedActivity: Activity | undefined;
  selectActivity: (id: string) => void;
  cancelSelectActivity: () => void;
  deleteActivity: (id: string) => void;
}

export default function ActivityList({
  activities,
  selectedActivity,
  selectActivity,
  cancelSelectActivity,
  deleteActivity,
}: Props) {
  return (
    <ListGroup>
      {activities
        .sort((a, b) => (a.date > b.date ? 1 : -1))
        .map((activity) => (
          <ListGroup.Item key={activity.id}>
            {activity.title}
            <span>{activity.date?.toString()}</span>
            <span>{activity.description}</span>
            <span>{activity.city}</span>
            <span>{activity.venue}</span>
            <Button
              onClick={() => selectActivity(activity.id)}
              className="view-button"
            >
              View
            </Button>
            <Button
              variant="danger"
              onClick={() => deleteActivity(activity.id)}
              className="view-button"
            >
              Delete
            </Button>
            <label>{activity.category}</label>
          </ListGroup.Item>
        ))}
    </ListGroup>
  );
}
